﻿namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.MediaInfo;
    using static DataValidation.DataValidation.ContactInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OperatingLocation
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(TownMaxLength)]
        public string Town { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        //------------ Employee [FK] -----------
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //------------ Department [FK] -----------
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();

        //------------ Reservations [FK] -----------
        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        //------------ ServiceOperatingLocation [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceOperatingLocation> Services { get; set; } = new HashSet<ServiceOperatingLocation>();
    }
}
