namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Qualifications;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IQualificationsService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Qualification"/> in the database using <see cref="CreateQualificationServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="Qualification"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Name</c> and <c>Description</c></param>
        /// <returns>Qualification ID</returns>
        Task<int> CreateAsync(CreateQualificationServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="Qualification"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="QualificationsDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="Qualification"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <returns>Collection of Qualifications</returns>
        IEnumerable<QualificationsDropdownServiceModel> GetAll();

        /// <summary>
        /// Describes a method which gets a <see cref="Qualification"/> from the database using the given (int) id.
        /// <para>Should return <see cref="QualificationServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Qualification"/>'s <c>Id</c>, <c>Name</c> and <c>Description</c>.</para>
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>A single Qualification</returns>
        QualificationServiceModel GetById(int id);

        /// <summary>
        /// Describes a method which gets a <see cref="Qualification"/> from the database using the given (string) name.
        /// <para>Should return <see cref="QualificationsDropdownServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Qualification"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <param name="name">Qualification Name</param>
        /// <returns>A single Qualification</returns>
        QualificationsDropdownServiceModel GetByName(string name);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="Qualification"/>s from the database.
        /// <para>Should return the number of <see cref="Qualification"/>s</para>
        /// </summary>
        /// <returns>Qualification Count</returns>
        int Count();

        /// <summary>
        /// Describes a method for getting all the <see cref="Qualification"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="QualificationsListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, FirstName, Name and Description</returns>
        IEnumerable<QualificationsListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes an asynchronous method for removing an <see cref="Qualification"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="Qualification"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="qualificationId">Qualification ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int qualificationId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="Qualification"/> using <see cref="EditQualificationServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c>, <c>Name</c> and <c>Description</c></param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditQualificationServiceModel model);
    }
}
