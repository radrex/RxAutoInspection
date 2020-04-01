namespace RxAuto.Web.ViewModels.OperatingLocations.InputModels
{
    using RxAuto.Web.ViewModels.Departments.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OperatingLocationInputModel
    {
        [Required(ErrorMessage = "Please enter Town name")]
        [StringLength(30, ErrorMessage = "Name should be 3 to 30 characters long", MinimumLength = 3)]
        public string Town { get; set; }

        [Required(ErrorMessage = "Please enter Town name")]
        [StringLength(50, ErrorMessage = "Name should be 10 to 50 characters long", MinimumLength = 10)]
        public string Address { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [MaxLength(2000)]
        public string ImageUrl { get; set; }

        //For multiple Id's passed from <select>
        [Display(Name = "Departments")]
        public int[] DepartmentIds { get; set; }

        public IEnumerable<DepartmentsDropdownViewModel> Departments { get; set; }
    }
}
