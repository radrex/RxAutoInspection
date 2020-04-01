namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Qualifications;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Describes functionality methods concering <see cref="Qualification"/> entity.
    /// </summary>
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
        /// <para>Should return <see cref="QualificationsDropdownServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Qualification"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>A single Qualification</returns>
        QualificationsDropdownServiceModel GetById(int id);

        /// <summary>
        /// Describes a method which gets a <see cref="Qualification"/> from the database using the given (string) name.
        /// <para>Should return <see cref="QualificationsDropdownServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Qualification"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <param name="name">Qualification Name</param>
        /// <returns>A single Qualification</returns>
        QualificationsDropdownServiceModel GetByName(string name);
    }
}
