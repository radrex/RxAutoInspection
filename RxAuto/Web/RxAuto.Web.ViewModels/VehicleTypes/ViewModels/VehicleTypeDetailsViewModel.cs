namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for VehicleType information with <c>Id</c>, <c>Name</c>, <c>VehicleCategory</c> and <c>Description</c>.
    /// </summary>
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
