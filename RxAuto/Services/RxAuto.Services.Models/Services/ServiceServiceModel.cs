namespace RxAuto.Services.Models.Services
{
    /// <summary>
    /// Service model for Service information with <c>Id</c>, <c>Name</c>, <c>IsShownInSubMenu</c>, <c>ServiceType</c>, <c>VehicleType</c>, <c>Description</c>, <c>Price</c> and collections of <c>OperatingLocationIds</c> and <c>DocumentIds</c>.
    /// </summary>
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
