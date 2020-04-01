namespace RxAuto.Web.ViewModels.Phones.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PhoneInputModel
    {
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter Phone Number")]
        //TODO: Add phone regex validation
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
