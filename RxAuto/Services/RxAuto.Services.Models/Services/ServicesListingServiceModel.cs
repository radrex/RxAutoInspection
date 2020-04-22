namespace RxAuto.Services.Models.Services
{
    /// <summary>
    /// Service model for listing an JobPosition's <c>Id</c>, <c>Name</c>, <c>IsShownInSubMenu</c>, <c>ServiceType</c>, <c>VehicleType</c> and <c>Price</c>.
    /// </summary>
    public class ServicesListingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsShownInSubMenu { get; set; }
        public string ServiceType { get; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
    }
}
