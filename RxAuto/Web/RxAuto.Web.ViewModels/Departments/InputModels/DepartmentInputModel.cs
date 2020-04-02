namespace RxAuto.Web.ViewModels.Departments.InputModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering Department information from the user. It includes <c>Name</c>, <c>Email</c>, <c>Description</c>, array of <c>PhoneNumberIds</c> and a collection of <c>PhoneNumbers</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
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

        public IEnumerable<PhonesDropdownViewModel> PhoneNumbers { get; set; }
    }
}
