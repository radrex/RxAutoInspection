namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.JobPositions;
    using RxAuto.Services.Models.Qualifications;

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

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="JobPositionsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public JobPositionsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
