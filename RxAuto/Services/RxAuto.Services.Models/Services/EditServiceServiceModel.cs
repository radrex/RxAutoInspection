namespace RxAuto.Services.Models.Services
{
    /// <summary>
    /// Service model for Service edit information with <c>Id</c>, <c>Name</c>, <c>Description</c>, <c>IsShownInSubMenu</c>, <c>ServiceTypeId</c>, <c>VehicleTypeId</c> and collections of <c>OperatingLocationIds</c> and <c>DocumentIds</c>.
    /// </summary>
    public class EditServiceServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsShownInSubMenu { get; set; }
        public int ServiceTypeId { get; set; }
        public int VehicleTypeId { get; set; }

        public int[] OperatingLocationIds { get; set; }
        public int[] DocumentIds { get; set; }
    }
}
