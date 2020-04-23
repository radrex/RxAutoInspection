namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    /// <summary>
    /// View model for VehicleType information with <c>Id</c>, <c>Name</c>, <c>VehicleCategory</c> and <c>Description</c>.
    /// </summary>
    public class VehicleTypeDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleCategory { get; set; }
        public string Description { get; set; }
    }
}
