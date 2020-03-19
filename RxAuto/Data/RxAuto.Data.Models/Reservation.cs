﻿namespace RxAuto.Data.Models
{
    using System;

    public class Reservation
    {
        //-------------- PROPERTIES ---------------
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsActive { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationDateTime { get; set; }

        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        //------------ User [FK] -----------
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
