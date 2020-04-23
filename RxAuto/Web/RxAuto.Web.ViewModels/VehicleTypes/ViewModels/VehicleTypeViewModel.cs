namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a VehicleType's information such as <c>Id</c>, <c>Name</c> and <c>VehicleCategory</c>.
    /// </summary>
    public class VehicleTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle Type Name")]
        public string Name { get; set; }

        public string VehicleCategory { get; set; }
    }
}
