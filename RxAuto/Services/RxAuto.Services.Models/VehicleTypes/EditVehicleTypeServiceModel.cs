using RxAuto.Data.Models.Enums;

namespace RxAuto.Services.Models.VehicleTypes
{
    public class EditVehicleTypeServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VehicleCategoryId { get; set; }
    }
}
