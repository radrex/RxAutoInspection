namespace RxAuto.Services.Models.VehicleTypes
{
    using RxAuto.Data.Models.Enums;

    public class VehicleTypeServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public VehicleCategory VehicleCategory { get; set; }
        public int VehicleCategoryId { get; set; }

        public string Description { get; set; }
    }
}
