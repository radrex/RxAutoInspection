namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.MediaInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Service
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsShownInSubMenu { get; set; }

        //------------ ServiceType [FK] -----------
        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; }

        //------------ VehicleType [FK] -----------
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        //------------ Reservation [FK] -----------
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        //------------ ServiceOperatingLocation [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceOperatingLocation> OperatingLocations { get; set; } = new HashSet<ServiceOperatingLocation>();

        //------------ ServiceDocument [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceDocument> Documents { get; set; } = new HashSet<ServiceDocument>();
    }
}
