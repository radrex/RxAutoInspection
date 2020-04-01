namespace RxAuto.Services.Models.OperatingLocations
{
    /// <summary>
    /// Service model for Dropdown listing a OperatingLocation's <c>Id</c>, <c>Town</c> and <c>Address</c> properties.
    /// </summary>
    public class OperatingLocationsDropdownServiceModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
