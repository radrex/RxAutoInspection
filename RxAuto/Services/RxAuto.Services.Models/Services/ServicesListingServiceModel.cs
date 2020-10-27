namespace RxAuto.Services.Models.Services
{
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
