namespace RxAuto.Services.Models.Reservations
{
    /// <summary>
    /// Service model for listing a Reservation's <c>Id</c>, <c>Service</c>, <c>IsActive</c>, <c>VehicleMake</c>, <c>VehicleModel</c>, <c>PhoneNumber</c> and <c>ReservationDateTime</c>.
    /// </summary>
    public class ReservationsListingServiceModel
    {
        public string Id { get; set; }
        public string ServiceType { get; set; }
        public string Service { get; set; }
        public string IsActive { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ReservationDateTime { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
