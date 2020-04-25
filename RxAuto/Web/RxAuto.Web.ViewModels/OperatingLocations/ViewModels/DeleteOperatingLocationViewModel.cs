namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for OperatingLocation delete confirmation data such as <c>Id</c>, <c>Town</c> and <c>Address</c>.
    /// </summary>
    public class DeleteOperatingLocationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Адес")]
        public string Address { get; set; }
    }
}
