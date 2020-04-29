namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.VehicleInfo;
    using static DataValidation.DataValidation.ContactInfo;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        //-------------- PROPERTIES ---------------
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public bool IsActive { get; set; } = true;

        [MaxLength(VehicleMakeMaxLength)]
        public string VehicleMake { get; set; }

        [MaxLength(VehicleModelMaxLength)]
        public string VehicleModel { get; set; }

        [Required]
        [MaxLength(LicenseNumberMaxLength)]
        public string LicenseNumber { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public DateTime ReservationDateTime { get; set; }

        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        //------------ User [FK] -----------
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public virtual OperatingLocation OperatingLocation { get; set; }
    }
}
