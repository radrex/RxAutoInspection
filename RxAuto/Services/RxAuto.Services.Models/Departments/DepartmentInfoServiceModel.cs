namespace RxAuto.Services.Models.Departments
{
    using RxAuto.Services.Models.Phones;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for listing a Department's information such as <c>Id</c>, <c>Name</c>, <c>Email</c> and a collection of <c>Phones</c>.
    /// </summary>
    public class DepartmentInfoServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // TODO: Add ImageUrl

        public IEnumerable<PhoneServiceModel> Phones { get; set; }
    }
}
