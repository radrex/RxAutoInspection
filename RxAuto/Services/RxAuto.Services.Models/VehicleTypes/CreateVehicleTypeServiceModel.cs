namespace RxAuto.Services.Models.VehicleTypes
{
    public class CreateVehicleTypeServiceModel
    {
        public string Name { get; set; }
        public int VehicleCategoryId { get; set; }
        public string Description { get; set; }
    }
}
