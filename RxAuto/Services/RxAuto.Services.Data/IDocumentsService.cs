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

        /// <summary>
        /// Describes a method for getting all the <see cref="Document"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="DocumentsListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, Name and Description</returns>
        IEnumerable<DocumentsListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="Document"/>s from the database.
        /// <para>Should return the number of <see cref="Document"/>s</para>
        /// </summary>
        /// <returns>Documents Count</returns>
        int Count();

        /// <summary>
        /// Describes a method which gets a <see cref="Document"/> from the database using the given (int) id.
        /// <para>Should return <see cref="DocumentServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Document"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns>A single Document</returns>
        DocumentServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="Document"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int documentId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="Document"/> using <see cref="EditDocumentServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Name</c> and <c>Description</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditDocumentServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="Document"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);
    }
}
