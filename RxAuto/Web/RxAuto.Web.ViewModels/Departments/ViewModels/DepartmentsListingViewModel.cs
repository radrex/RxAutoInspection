namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using System.Collections.Generic;

    public class DepartmentsListingViewModel
    {
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
