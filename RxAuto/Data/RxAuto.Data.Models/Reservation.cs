namespace RxAuto.Data.Models
{
    using System;

    public class Reservation
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }

        //------------ Town [FK] -----------
        public int TownId { get; set; }
        public Town Town { get; set; }

        //------------ Vehicle [FK] -----------
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
