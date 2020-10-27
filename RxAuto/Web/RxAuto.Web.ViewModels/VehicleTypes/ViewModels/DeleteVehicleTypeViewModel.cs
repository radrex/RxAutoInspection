namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteVehicleTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на Категория")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Категоррия")]
        public string VehicleCategory { get; set; }
    }
}
