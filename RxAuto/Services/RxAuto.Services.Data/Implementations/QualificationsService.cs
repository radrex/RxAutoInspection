namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;

    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Qualifications;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="Qualification"/> entity and it's database relations.
    /// </summary>
    public class QualificationsService : IQualificationsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="QualificationsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public QualificationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="Qualification"/> using the <see cref="CreateQualificationServiceModel"/>.
        /// If such <see cref="Qualification"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="Qualification"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>Qualification ID</returns>
        public async Task<int> CreateAsync(CreateQualificationServiceModel model)
        {
            int qualificationId = this.dbContext.Qualifications.Where(x => x.Name == model.Name)
                                                               .Select(x => x.Id)
                                                               .FirstOrDefault();

            if (qualificationId != 0)   // If qualificationId is different than 0 (int default value), qualification with such name already exists, so return it's id.
            {
                return qualificationId;
            }

            Qualification qualification = new Qualification
            {
                Name = model.Name,
                Description = model.Description,
            };

            await this.dbContext.Qualifications.AddAsync(qualification);
            await this.dbContext.SaveChangesAsync();

            return qualification.Id;
        }

        /// <summary>
        /// Gets every <see cref="Qualification"/>'s <c>Id</c> and <c>Name</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of Qualifications</returns>
        public IEnumerable<QualificationsDropdownServiceModel> GetAll()
        {
            return this.dbContext.Qualifications.Select(q => new QualificationsDropdownServiceModel
                                                {                                                
                                                    Id = q.Id,
                                                    Name = q.Name,
                                                }).ToList();
        }

        /// <summary>
        /// Gets the first <see cref="Qualification"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Name</c> and <c>Description</c> as a service model.
        /// <para> If there is no such <see cref="Qualification"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>A single Qualification</returns>
        public QualificationServiceModel GetById(int id)
        {
            return this.dbContext.Qualifications.Where(q => q.Id == id)
                                                .Select(q => new QualificationServiceModel
                                                {
                                                    Id = q.Id,
                                                    Name = q.Name,
                                                    Description = q.Description,
                                                }).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first <see cref="Qualification"/> by <c>Name</c> from the database and returns it's <c>Id</c> and <c>Name</c> as a service model.
        /// <para> If there is no such <see cref="Qualification"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="name">Qualification Name</param>
        /// <returns>A single Qualification</returns>
        public QualificationsDropdownServiceModel GetByName(string name)
        {
            return this.dbContext.Qualifications.Where(q => q.Name == name)
                                                .Select(q => new QualificationsDropdownServiceModel
                                                {
                                                    Id = q.Id,
                                                    Name = q.Name,
                                                }).FirstOrDefault();
        }

        /// <summary>
        /// Gets and returns the total <c>Qualifications</c> count.
        /// </summary>
        /// <returns>Qualifications Count</returns>
        public int Count()
        {
            return this.dbContext.Qualifications.Count();
        }

        /// <summary>
        /// Gets every <see cref="Qualification"/>'s <c>Id</c>, <c>Name</c> and <c>Description</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of Qualifications</returns>
        public IEnumerable<QualificationsListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.Qualifications.Select(x => new QualificationsListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            })
            .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }

        /// <summary>
        /// Removes an <see cref="Qualification"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            Qualification qualification = this.dbContext.Qualifications.Find(id);
            if (qualification == null)
            {
                return false;
            }

            var jobPositionQualifications = this.dbContext.JobPositionQualifications
                                                          .Where(x => x.QualificationId == qualification.Id)
                                                          .ToList();

            this.dbContext.JobPositionQualifications.RemoveRange(jobPositionQualifications);
            this.dbContext.Qualifications.Remove(qualification);
            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Searches the database for a <see cref="Qualification"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="qualificationId">Qualification ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int qualificationId)
        {
            return this.dbContext.Qualifications.Any(x => x.Id == qualificationId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="Qualification"/> using <see cref="EditQualificationServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Name</c> and <c>Description</c></returns>
        public async Task<int> EditAsync(EditQualificationServiceModel model)
        {
            Qualification qualification = this.dbContext.Qualifications.Find(model.Id);

            qualification.Name = model.Name;
            qualification.Description = model.Description;

            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }
    }
}
