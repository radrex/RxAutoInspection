namespace RxAuto.Data.Seeding.JSONSeed
{
    using System;

    public class JReservation
    {
        public bool IsActive { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int ServiceId { get; set; }
        public string Username { get; set; }
        public int OperatingLocationId { get; set; }
    }
}
