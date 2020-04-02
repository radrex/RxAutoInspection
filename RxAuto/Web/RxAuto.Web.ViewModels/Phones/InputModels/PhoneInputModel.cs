namespace RxAuto.Web.ViewModels.Phones.InputModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering Phone information from the user. It includes <c>PhoneNumber</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class PhoneInputModel
    {
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter Phone Number")]
        //TODO: Add phone regex validation
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
