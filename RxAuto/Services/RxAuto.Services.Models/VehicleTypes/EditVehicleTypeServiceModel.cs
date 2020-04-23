using RxAuto.Data.Models.Enums;

namespace RxAuto.Services.Models.VehicleTypes
{
    /// <summary>
    /// Service model for VehicleType edit information with <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>VehicleCategory</c>.
    /// </summary>
    public class EditVehicleTypeServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VehicleCategoryId { get; set; }
    }
}
