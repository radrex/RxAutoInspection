namespace RxAuto.Services.Models.VehicleTypes
{
    /// <summary>
    /// Service model for Creating a VehicleType with <c>Name</c>, <c>VehicleCategoryId</c> and <c>Description</c>.
    /// </summary>
    public class CreateVehicleTypeServiceModel
    {
        public string Name { get; set; }
        public int VehicleCategoryId { get; set; }
        public string Description { get; set; }
    }
}
