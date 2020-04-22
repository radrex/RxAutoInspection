namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    /// <summary>
    /// View model for Service information with <c>Id</c>, <c>Name</c>, <c>IsShownInSubMenu</c>, <c>ServiceType</c>, <c>VehicleType</c>, <c>Description</c> and <c>Price</c>.
    /// </summary>
    public class ServiceDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsShownInSubMenu { get; set; }
        public string ServiceType { get; set; }
        public string VehicleType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
