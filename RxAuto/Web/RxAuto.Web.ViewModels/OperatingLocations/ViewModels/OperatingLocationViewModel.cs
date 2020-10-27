using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    public class OperatingLocationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        // TODO: Add departments, emloyees, services to view foreach operatingLocation
    }
}
