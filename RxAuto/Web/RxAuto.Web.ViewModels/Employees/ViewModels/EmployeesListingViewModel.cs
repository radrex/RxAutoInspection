namespace RxAuto.Web.ViewModels.Employees.ViewModels
{
    using System.Collections.Generic;

    public class EmployeesListingViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
