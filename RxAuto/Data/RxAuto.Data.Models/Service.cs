namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class Service
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //------------ ServiceType [FK] -----------
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        //------------ Reservation [FK] -----------
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        //------------ ServiceOperatingLocation [FK] MAPPING TABLE -----------
        public ICollection<ServiceOperatingLocation> OperatingLocations { get; set; } = new HashSet<ServiceOperatingLocation>();

        //------------ ServiceVehicleType [FK] MAPPING TABLE -----------
        public ICollection<ServiceVehicleType> VehicleTypes { get; set; } = new HashSet<ServiceVehicleType>();

        //------------ ServiceDocument [FK] MAPPING TABLE -----------
        public ICollection<ServiceDocument> Documents { get; set; } = new HashSet<ServiceDocument>();
    }
}
