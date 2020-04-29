using System;

namespace RxAuto.Services.Models.Reservations
{
    //TODO: Add docs
    public class CreateReservationServiceModel
    {
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string PhoneNumber { get; set; }
        public int ServiceId { get; set; }
        public int OperatingLocationId { get; set; }
        public string Username { get; set; }
    }
}
