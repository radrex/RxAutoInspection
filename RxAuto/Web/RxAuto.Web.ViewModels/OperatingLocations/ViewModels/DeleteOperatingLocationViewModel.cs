namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteOperatingLocationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Адес")]
        public string Address { get; set; }
    }
}
