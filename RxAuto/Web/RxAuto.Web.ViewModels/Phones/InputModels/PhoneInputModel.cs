namespace RxAuto.Web.ViewModels.Phones.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PhoneInputModel
    {
        public int Id { get; set; }

        [Display(Name = "Телефон", Prompt = "Телефон")]
        [Required(ErrorMessage = "Моля въведете Телефон")]
        [RegularExpression(@"^([+]?359)|0?(|-| )8[789]\d{1}(|-| )\d{3}(|-| )\d{3}$", ErrorMessage = "Невалиден Телефон")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }
}
