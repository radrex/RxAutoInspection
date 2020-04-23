namespace RxAuto.Services.Models.VehicleTypes
{
    /// <summary>
    /// Service model for listing an JobPosition's <c>Id</c>, <c>Name</c> and <c>VehicleCategory</c>.
    /// </summary>
    public class VehicleTypesListingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleCategory { get; set; }
    }
}
