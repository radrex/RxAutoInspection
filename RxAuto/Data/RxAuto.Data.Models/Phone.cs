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

        // All phones are internal on creation, later when we specify which phones to be visible for the user - change the value to false.
        public bool IsInternal { get; set; } = true; 

        //------------ DepartmentPhone [FK] MAPPING TABLE -----------
        public virtual ICollection<DepartmentPhone> Departments { get; set; } = new HashSet<DepartmentPhone>();
    }
}
