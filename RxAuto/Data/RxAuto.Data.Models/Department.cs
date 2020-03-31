namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.MediaInfo;
    using static DataValidation.DataValidation.ContactInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public virtual OperatingLocation OperatingLocation { get; set; }

        //------------ DepartmentPhone [FK] MAPPING TABLE -----------
        public virtual ICollection<DepartmentPhone> Phones { get; set; } = new HashSet<DepartmentPhone>();
    }
}
