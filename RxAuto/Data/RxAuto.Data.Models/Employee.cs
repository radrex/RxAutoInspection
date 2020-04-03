namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.MediaInfo;
    using static DataValidation.DataValidation.PersonInfo;
    using static DataValidation.DataValidation.ContactInfo;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        //-------------- PROPERTIES ---------------
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(PersonNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(PersonNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(PersonNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(TownMaxLength)]
        public string Town { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        //------------ JobPosition [FK] -----------
        public int JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public virtual OperatingLocation OperatingLocation { get; set; }
    }
}
