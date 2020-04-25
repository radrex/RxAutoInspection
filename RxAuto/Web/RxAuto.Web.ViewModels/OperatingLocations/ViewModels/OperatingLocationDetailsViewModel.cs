using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    /// <summary>
    /// View model for OperatingLocation information with <c>Id</c>, <c>Town</c> and <c>Address</c>.
    /// </summary>
    public class OperatingLocationDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }
}
