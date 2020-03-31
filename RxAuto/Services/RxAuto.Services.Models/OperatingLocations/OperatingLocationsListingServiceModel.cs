namespace RxAuto.Services.Models.OperatingLocations
{
    /// <summary>
    /// Service model for Listing an OperatingLocation's <c>Id</c> and <c>Town</c> properties.
    /// </summary>
    public class OperatingLocationsListingServiceModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
