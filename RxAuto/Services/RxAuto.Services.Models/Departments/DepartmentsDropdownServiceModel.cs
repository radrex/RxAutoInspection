namespace RxAuto.Services.Models.Departments
{
    using RxAuto.Services.Models.Phones;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for Dropdown listing of a Department's <c>Id</c>, <c>Name</c>, <c>Email</c> and collection of <c>Phone</c>'s.
    /// </summary>
    public class DepartmentsDropdownServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<PhonesDropdownServiceModel> Phones { get; set; }
    }
}
