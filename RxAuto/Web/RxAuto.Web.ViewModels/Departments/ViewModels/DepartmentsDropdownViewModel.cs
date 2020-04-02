namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using System.Collections.Generic;

    /// <summary>
    /// View model for Dropdown listing of a Department's <c>Id</c>, <c>Name</c>, <c>Email</c> and collection of <c>Phone</c>'s.
    /// </summary>
    public class DepartmentsDropdownViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<PhonesDropdownViewModel> Phones { get; set; }
    }
}
