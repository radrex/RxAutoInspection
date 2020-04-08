namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Documents;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Describes functionality methods concering <see cref="Document"/> entity.
    /// </summary>
    public interface IDocumentsService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Document"/> in the database using <see cref="CreateDocumentServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="Document"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>Document ID</returns>
        Task<int> CreateAsync(CreateDocumentServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="Document"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="DocumentsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="Document"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <returns>Collection of Departments</returns>
        IEnumerable<DocumentsDropdownServiceModel> GetAll();
    }
}
