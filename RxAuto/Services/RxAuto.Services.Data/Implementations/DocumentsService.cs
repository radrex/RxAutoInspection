namespace RxAuto.Services.Data.Implementations
{
    using RxAuto.Data;
    using RxAuto.Data.Models;

    using RxAuto.Services.Models.Documents;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains method implementations for <see cref="Document"/> entity and it's database relations.
    /// </summary>
    public class DocumentsService : IDocumentsService
    {
        //---------------- FIELDS -----------------
        private readonly ApplicationDbContext dbContext;
        private readonly IServicesService servicesService;

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="DocumentsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public DocumentsService(ApplicationDbContext dbContext, IServicesService servicesService)
        {
            this.dbContext = dbContext;
            this.servicesService = servicesService;
        }

        //--------------- METHODS -----------------
        /// <summary>
        /// Creates a new <see cref="Document"/> using the <see cref="CreateDocumentServiceModel"/>.
        /// If such <see cref="Document"/> already exists in the database, fetches it's (int)<c>Id</c> and returns it.
        /// If such <see cref="Document"/> doesn't exist in the database, adds it and return it's (int)<c>Id</c>.
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>Document ID</returns>
        public async Task<int> CreateAsync(CreateDocumentServiceModel model)
        {
            int documentId = this.dbContext.Documents.Where(d => d.Name == model.Name)
                                                     .Select(x => x.Id)
                                                     .FirstOrDefault();

            if (documentId != 0)   // If documentId is different than 0 (int default value), document with such name already exists, so return it's id.
            {
                return documentId;
            }

            Document document = new Document
            {
                Name = model.Name,
                Description = model.Description,
            };

            await this.dbContext.Documents.AddAsync(document);
            await this.dbContext.SaveChangesAsync();

            return document.Id;
        }

        /// <summary>
        /// Gets every <see cref="Document"/>'s <c>Id</c> and <c>Name</c> from the database and returns it as a service model collection.
        /// </summary>
        /// <returns>Collection of Documents</returns>
        public IEnumerable<DocumentsDropdownServiceModel> GetAll()
        {
            return this.dbContext.Documents.Select(d => new DocumentsDropdownServiceModel
            {
                Id = d.Id,
                Name = d.Name,
            }).ToList();
        }

        /// <summary>
        /// Gets every <see cref="Document"/>'s <c>Id</c>, <c>Name</c> and <c>Description</c> and returns it as a service model collection.
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Collection of Documents</returns>
        public IEnumerable<DocumentsListingServiceModel> All(int? take = null, int skip = 0)
        {
            var query = this.dbContext.Documents.Select(x => new DocumentsListingServiceModel
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
        /// Gets and returns the total <c>Documents</c> count.
        /// </summary>
        /// <returns>Documents Count</returns>
        public int Count()
        {
            return this.dbContext.Documents.Count();
        }

        /// <summary>
        /// Gets the first <see cref="Document"/> by (int)<c>Id</c> from the database and returns it's <c>Id</c>, <c>Name</c> and <c>Description</c> as a service model.
        /// <para> If there is no such <see cref="Document"/> in the database, returns the service model default value.</para>
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns>A single Document</returns>
        public DocumentServiceModel GetById(int id)
        {
            return this.dbContext.Documents.Where(x => x.Id == id)
                                           .Select(x => new DocumentServiceModel
                                           {
                                               Id = x.Id,
                                               Name = x.Name,
                                               Description = x.Description,
                                           }).FirstOrDefault();
        }

        /// <summary>
        /// Searches the database for a <see cref="Document"/> with the given <c>Id</c>.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>True - found. False - not found.</returns>
        public bool Exists(int documentId)
        {
            return this.dbContext.Documents.Any(x => x.Id == documentId); // TODO: Use AnyAsync ?
        }

        /// <summary>
        /// Edits the <see cref="Document"/> using <see cref="EditDocumentServiceModel"/>.
        /// </summary>
        /// <param name="model">Number of modified entities.</param>
        /// <returns>Service model with <c>Id</c>, <c>Name</c> and <c>Description</c>.</returns>
        public async Task<int> EditAsync(EditDocumentServiceModel model)
        {
            Document document = this.dbContext.Documents.Find(model.Id);
            document.Name = model.Name;
            document.Description = model.Description;
            
            int modifiedEntities = await this.dbContext.SaveChangesAsync();
            return modifiedEntities;
        }

        /// <summary>
        /// Removes a <see cref="Document"/> with the given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        public async Task<bool> RemoveAsync(int id)
        {
            Document document = this.dbContext.Documents.Find(id);
            if (document == null)
            {
                return false;
            }

            // First Delete all serviceDocument related entities (Mapping table)
            this.dbContext.ServiceDocuments.RemoveRange(document.Services);

            // And lastly Delete the document itself
            this.dbContext.Documents.Remove(document);

            int deletedEntities = await this.dbContext.SaveChangesAsync();

            if (deletedEntities == 0)
            {
                return false;
            }
            return true;
        }
    }
}
