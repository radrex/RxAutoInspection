namespace RxAuto.Services.Models.Services
{
    public class ServiceServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsShownInSubMenu { get; set; }
        public string ServiceType { get; set; }
        public string VehicleType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int VehicleTypeId { get; set; }
        public int ServiceTypeId { get; set; }

        public int[] OperatingLocationIds { get; set; }
        public int[] DocumentIds { get; set; }
    }
}
