namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Department information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class DepartmentsListingViewModel
    {
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
