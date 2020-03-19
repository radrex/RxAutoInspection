namespace RxAuto.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        //-------------- PROPERTIES ---------------
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }

        //------------ JobPosition [FK] -----------
        public int JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public OperatingLocation OperatingLocation { get; set; }

        //------------ EmployeeQualification [FK] MAPPING TABLE -----------
        public virtual ICollection<EmployeeQualification> Qualifications { get; set; } = new HashSet<EmployeeQualification>();
    }
}
