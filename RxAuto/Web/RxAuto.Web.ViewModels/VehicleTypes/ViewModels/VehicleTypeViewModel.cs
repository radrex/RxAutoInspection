namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a VehicleType's information such as <c>Id</c>, <c>Name</c> and <c>VehicleCategory</c>.
    /// </summary>
    public class VehicleTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име на Категория")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string VehicleCategory { get; set; }
    }
}
