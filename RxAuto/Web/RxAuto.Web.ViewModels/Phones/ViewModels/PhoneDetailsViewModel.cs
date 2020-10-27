using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.Phones.ViewModels
{
    public class PhoneDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Публичност")]
        public string IsInternal { get; set; }
    }
}
