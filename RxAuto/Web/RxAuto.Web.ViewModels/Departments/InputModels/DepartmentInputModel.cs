namespace RxAuto.Web.ViewModels.Departments.InputModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DepartmentInputModel
    {
        [Required(ErrorMessage = "Please enter Department name")]
        [StringLength(150, ErrorMessage = "Name should be 5 to 150 characters long", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [MaxLength(254)]
        //TODO: Add regex email validation
        public string Email { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        //For multiple Id's passed from <select>
        [Display(Name = "Phone Numbers")]
        public int[] PhoneNumberIds { get; set; }

        public IEnumerable<PhonesListingViewModel> PhoneNumbers { get; set; }
    }
}
