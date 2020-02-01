namespace RxAuto.Data.Models
{
    using RxAuto.Data.Models.Enums;
    using System.Collections.Generic;

    public class Service
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Address { get; set; }

        //TODO: Price table ?


        //------------ Reservation [FK] -----------
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();


        //------------ ServiceDocument [FK] MAPPING TABLE -----------
        public ICollection<ServiceDocument> Documents { get; set; } = new HashSet<ServiceDocument>();


        //------------ TownService [FK] MAPPING TABLE -----------
        public ICollection<TownService> Towns { get; set; } = new HashSet<TownService>();


        //------------ ServiceVehicleCategory [FK] MAPPING TABLE -----------
        public ICollection<ServiceVehicleCategory> VehicleCategories { get; set; } = new HashSet<ServiceVehicleCategory>();
    }
}
