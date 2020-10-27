namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Phones;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IPhonesService
    {
        /// <summary>
        /// Describes an asynchronous method for creating and adding a <see cref="Phone"/> in the database using <see cref="CreatePhoneServiceModel"/>.
        /// <para>Should return the ID (int) of the <see cref="Phone"/>.</para>
        /// </summary>
        /// <param name="model">Service model with <c>PhoneNumber</c></param>
        /// <returns>Phone ID</returns>
        Task<int> CreateAsync(CreatePhoneServiceModel model);

        /// <summary>
        /// Describes a method which gets all <see cref="Phone"/>'s from the database.
        /// <para>Should return IEnumerable&lt;<see cref="PhonesDropdownServiceModel"/>&gt;.</para>
        /// <para>Each service model has <see cref="Phone"/>'s <c>Id</c> and <c>PhoneNumber</c>.</para>
        /// </summary>
        /// <returns>Collection of Phones</returns>
        IEnumerable<PhonesDropdownServiceModel> GetAll();

        /// <summary>
        /// Describes a method which checks if the passed <c>Phone</c> is contained in more than 1 <c>Department</c>
        /// </summary>
        /// <param name="phone">Phone Number</param>
        /// <returns>True - phone is used in many departments. False - phone is used in one department.</returns>
        bool IsPhoneContainedInOtherDepartments(string phone);

        /// <summary>
        /// Describes a method for getting the total number of <see cref="Phone"/>s from the database.
        /// <para>Should return the number of <see cref="Phone"/>s</para>
        /// </summary>
        /// <returns>Phone Count</returns>
        int Count();

        /// <summary>
        /// Describes a method for getting all the <see cref="Phone"/>s from the database with parameters for pagination.
        /// <para>Should return a collection of <see cref="PhonesListingServiceModel"/>.</para>
        /// </summary>
        /// <param name="take">Pages to take</param>
        /// <param name="skip">Pages to skip</param>
        /// <returns>Service Model with Id, PhoneNumber and IsInternal</returns>
        IEnumerable<PhonesListingServiceModel> All(int? take = null, int skip = 0);

        /// <summary>
        /// Describes a method which gets a <see cref="Phone"/> from the database using the given (int) id.
        /// <para>Should return <see cref="PhoneServiceModel"/>.</para>
        /// <para>Each service model has <see cref="Phone"/>'s <c>Id</c> and <c>Name</c>.</para>
        /// </summary>
        /// <param name="id">Phone ID</param>
        /// <returns>A single Phone</returns>
        PhoneServiceModel GetById(int id);

        /// <summary>
        /// Describes a method for searching a <see cref="Phone"/> with given <c>Id</c>.
        /// </summary>
        /// <param name="phoneId">JobPosition ID</param>
        /// <returns>True - found. False - not found.</returns>
        bool Exists(int phoneId);

        /// <summary>
        /// Describes an asynchronous method for editing a <see cref="Phone"/> using <see cref="EditPhoneServiceModel"/>.
        /// <para>Should return the number of modified entities.</para>
        /// </summary>
        /// <param name="model">Service model with <c>Id</c> and <c>PhoneNumber</c>.</param>
        /// <returns>Number of modified entities.</returns>
        Task<int> EditAsync(EditPhoneServiceModel model);

        /// <summary>
        /// Describes an asynchronous method for removing a <see cref="Phone"/> with given <c>Id</c> from the database.
        /// </summary>
        /// <param name="id">Phone ID</param>
        /// <returns>True - removed entity. False - no such entity found.</returns>
        Task<bool> RemoveAsync(int id);
    }
}
