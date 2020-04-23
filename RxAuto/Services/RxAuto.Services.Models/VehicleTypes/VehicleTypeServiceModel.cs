namespace RxAuto.Services.Models.VehicleTypes
{
    using RxAuto.Data.Models.Enums;

    /// <summary>
    /// Service model for VehicleType information with <c>Id</c>, <c>Name</c>, <c>VehicleCategory</c> and <c>Description</c>.
    /// </summary>
    public class VehicleTypeServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public VehicleCategory VehicleCategory { get; set; }
        public int VehicleCategoryId { get; set; }

        public string Description { get; set; }
    }
}
