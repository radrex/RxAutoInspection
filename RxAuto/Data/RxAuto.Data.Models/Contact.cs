namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.ContactInfo;

    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public OperatingLocation OperatingLocation { get; set; }
    }
}
