namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class VehicleTypeDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на категория")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string VehicleCategory { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
