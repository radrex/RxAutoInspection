namespace RxAuto.Web.ViewModels.Employees.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Employees information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class EmployeesListingViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
