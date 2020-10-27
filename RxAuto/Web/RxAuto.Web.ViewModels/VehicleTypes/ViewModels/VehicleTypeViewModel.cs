namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class VehicleTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на Категория")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string VehicleCategory { get; set; }
    }
}
