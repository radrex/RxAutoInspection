namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    using RxAuto.Web.ViewModels.Departments.ViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OperatingLocationInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        // TODO: Add ImageUrl

        [Display(Name = "Отдели")]
        public IEnumerable<DepartmentInfoViewModel> Departments { get; set; }
    }
}
