namespace RxAuto.Services.Models.OperatingLocations
{
    /// <summary>
    /// Service model for listing a OperatingLocation's <c>Id</c>, <c>Town</c> and <c>Address</c>.
    /// </summary>
    public class OperatingLocationsListingServiceModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
