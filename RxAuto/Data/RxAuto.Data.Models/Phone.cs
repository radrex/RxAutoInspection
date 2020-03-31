namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.ContactInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Phone
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        //------------ DepartmentPhone [FK] MAPPING TABLE -----------
        public virtual ICollection<DepartmentPhone> Departments { get; set; } = new HashSet<DepartmentPhone>();
    }
}
