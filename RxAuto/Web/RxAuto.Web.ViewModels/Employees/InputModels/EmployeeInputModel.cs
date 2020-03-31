namespace RxAuto.Web.ViewModels.Employees.InputModels
{
    using RxAuto.Web.ViewModels.JobPositions.ViewModel;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeInputModel
    {
        [Display(Name = "Job Position")]
        [Required]
        [Range(100, int.MaxValue)]
        public int JobPositionId { get; set; }
        public IEnumerable<JobPositionsListingViewModel> JobPositions { get; set; }


        [Display(Name = "Operating Location")]
        [Required]
        [Range(10, int.MaxValue)]
        public int OperatingLocationId { get; set; }
        public IEnumerable<OperatingLocationsListingViewModel> OperatingLocations { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        [StringLength(20, ErrorMessage = "Name should be 2 to 20 characters long", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Please enter Middle Name")]
        [StringLength(20, ErrorMessage = "Name should be 2 to 20 characters long", MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        [StringLength(20, ErrorMessage = "Name should be 2 to 20 characters long", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter Phone number")]
        //TODO: Add regex validation
        public string Phone { get; set; }

        //TODO: Add regex validation
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Home Town")]
        [StringLength(30, ErrorMessage = "Name should be 3 to 30 characters long", MinimumLength = 3)]
        public string Town { get; set; }

        [Required(ErrorMessage = "Please enter Home Address")]
        [StringLength(50, ErrorMessage = "Name should be 8 to 50 characters long", MinimumLength = 8)]
        public string Address { get; set; }

        [MaxLength(2000)]
        public string ImageUrl { get; set; }
    }
}
