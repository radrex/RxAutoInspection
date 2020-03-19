namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class OperatingLocation
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        //------------ Employee [FK] -----------
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //------------ Employee [FK] -----------
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        //------------ ServiceOperatingLocation [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceOperatingLocation> Services { get; set; } = new HashSet<ServiceOperatingLocation>();
    }
}
