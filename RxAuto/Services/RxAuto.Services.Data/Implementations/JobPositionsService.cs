namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.JobPositions;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="JobPosition"/> entity and it's database relations.
    /// </summary>
    public class JobPositionsService : IJobPositionsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;
        private readonly IEmployeesService employeesService;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="JobPositionsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public JobPositionsService(ApplicationDbContext dbContext, IEmployeesService employeesService)
        {
            this.dbContext = dbContext;
            this.employeesService = employeesService;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="JobPosition"/> using the <see cref="CreateJobPositionServiceModel"/>.
        /// If such <see cref="JobPosition"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="JobPosition"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and a collection of <c>Qualifications</c></param>
        /// <returns>Job Position ID</returns>
        public async Task<int> CreateAsync(CreateJobPositionServiceModel model)
        {
            int jobPositionId = this.dbContext.JobPositions.Where(x => x.Name == model.Name)
                                                           .Select(x => x.Id)
                                                           .FirstOrDefault();

            if (jobPositionId != 0)   // If jobPositionId is different than 0 (int default value), jobPosition with such name already exists, so return it's id.
            {
                return jobPositionId;
            }

            JobPosition jobPosition = new JobPosition
            {
                Name = model.Name,
            };

            foreach (var qualification in model.Qualifications)
            {
                await this.dbContext.JobPositionQualifications.AddAsync(new JobPositionQualification
                {
                    JobPosition = jobPosition,
                    QualificationId = qualification.Id,
                });
            }

            // Adds job position without any qualifications
            if (model.Qualifications.Count() == 0)
            {
                await this.dbContext.JobPositions.AddAsync(jobPosition);
            }

            await this.dbContext.SaveChangesAsync();
            return jobPosition.Id;
        }

        /// <summary>
        /// Gets every <see cref="JobPosition"/>'s <c>Id</c> and <c>Name</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of JobPositions</returns>
        public IEnumerable<JobPositionsDropdownServiceModel> GetAll()
        {
            return this.dbContext.JobPositions.Select(jp => new JobPositionsDropdownServiceModel
            {
                Id = jp.Id,
                Name = jp.Name,
            }).ToList();
        }

        /// <summary>
        /// Gets every <see cref="JobPosition"/>'s <c>Id</c> and <c>Name</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of JobPositions</returns>
        public IEnumerable<JobPositionsListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.JobPositions.Select(x => new JobPositionsListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Gets and returns the total <c>JobPositions</c> count.
        /// </summary>
        /// <returns>JobPositions Count</returns>
        public int Count()
        {
            return this.dbContext.JobPositions.Count();
        }

        /// <summary>
        /// Gets the first <see cref="JobPosition"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c> and <c>Name</c> as a service model.
        /// <para> If there is no such <see cref="JobPosition"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>A single JobPosition</returns>
        public JobPositionServiceModel GetById(int id)
        {
            return this.dbContext.JobPositions.Where(x => x.Id == id)
                                              .Select(x => new JobPositionServiceModel
                                              {
                                                  Id = x.Id,
                                                  Name = x.Name,
                                                  QualificationIds = x.Qualifications.Select(q => q.QualificationId).ToArray(),
                                              }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="JobPosition"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="jobPositionId">Employe ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int jobPositionId)
        {
            return this.dbContext.JobPositions.Any(x => x.Id == jobPositionId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="JobPosition"/> using <see cref="EditJobPositionServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Name</c> and <c>QualificationIds</c>.</returns>
        public async Task<int> EditAsync(EditJobPositionServiceModel model)
        {
            JobPosition jobPosition = this.dbContext.JobPositions.Find(model.Id);
            jobPosition.Name = model.Name;

            // First Remove jobPositionQualification related entity (Mapping table) for that jobPosition
            for (int i = 0; i < jobPosition.Qualifications.Count; i++)
            {
                this.dbContext.JobPositionQualifications.Remove(jobPosition.Qualifications.ToArray()[i]);
                await this.dbContext.SaveChangesAsync();
                i--;
            }

            // Then Add the new jobPositionQualification related entities (Mapping table) for that jobPosition with the new Qualifications
            foreach (var qualificationId in model.QualificationIds)
            {
                await this.dbContext.JobPositionQualifications.AddAsync(new JobPositionQualification
                {
                    JobPosition = jobPosition,
                    QualificationId = qualificationId,
                });
            }

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="JobPosition"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            JobPosition jobPosition = this.dbContext.JobPositions.Find(id);
            if (jobPosition == null)
            {
                return false;
            }

            // First Delete cascade all employees with that jobPosition
            for (int i = 0; i < jobPosition.Employees.Count; i++)
            {
                await this.employeesService.RemoveAsync(jobPosition.Employees.ToArray()[i].Id);
                i--;
            }

            // Then Delete all jobPositionQualification related entities (Mapping table)
            this.dbContext.JobPositionQualifications.RemoveRange(jobPosition.Qualifications);

            // And lastly Delete the jobPosition itself
            this.dbContext.JobPositions.Remove(jobPosition);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}
