namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Phones;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Describes functionality methods concering <see cref="Phone"/> entity.
    /// </summary>
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
    }
}
