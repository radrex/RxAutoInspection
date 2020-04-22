namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    /// <summary>
    /// View model for Service delete confirmation data such as <c>Id</c>, <c>Name</c>, <c>Price</c>, <c>Description</c>, <c>ServiceType</c>, <c>VehicleType</c> and <c>IsShownInSubMenu</c>.
    /// </summary>
    public class DeleteServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ServiceType { get; set; }
        public string VehicleType { get; set; }
        public string IsShownInSubMenu { get; set; }
    }
}
