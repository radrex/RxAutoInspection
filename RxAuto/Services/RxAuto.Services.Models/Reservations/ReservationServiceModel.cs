namespace RxAuto.Services.Models.Reservations
{
    /// <summary>
    /// Service model for listing a Service's information such as <c>Id</c>, <c>Service</c>, <c>VehicleMake</c>, <c>VehicleModel</c>, <c>LicenseNumber</c>, <c>PhoneNumber</c> and <c>ReservationDateTime</c>.
    /// </summary>
    public class ReservationServiceModel
    {
        public string Id { get; set; }
        public string IsActive { get; set; }
        public string ServiceType { get; set; }
        public string Service { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ReservationDateTime { get; set; }
    }
}
