namespace RxAuto.Services.Models.VehicleTypes
{
    /// <summary>
    /// Service model for Dropdown listing of a VehicleType's <c>Id</c>, <c>Category</c> and <c>Name</c> properties.
    /// </summary>
    public class VehicleTypesDropdownServiceModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
    }
}
