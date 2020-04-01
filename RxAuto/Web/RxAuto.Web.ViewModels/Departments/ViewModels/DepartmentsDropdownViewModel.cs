namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using System.Collections.Generic;

    public class DepartmentsDropdownViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<PhonesDropdownViewModel> Phones { get; set; }
    }
}
