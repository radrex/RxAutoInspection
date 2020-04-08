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

        //------------- CONSTRUCTORS --------------
        /// <summary>
        /// Initializes a new <see cref="DocumentsService"/>.
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public DocumentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
