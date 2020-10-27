using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    public class OperatingLocationDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }
}
