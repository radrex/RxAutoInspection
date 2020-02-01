namespace RxAuto.Data.Models
{
    using RxAuto.Data.Models.Enums;
    using System.Collections.Generic;

    public class Vehicle
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicenseNumber { get; set; }

        //------------ VehicleCategory [FK] -----------
        public int VehicleCategoryId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }

        //------------ Reservation [FK] -----------
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

    }
}
