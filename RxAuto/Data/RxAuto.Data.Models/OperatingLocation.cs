namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class OperatingLocation
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }

        //------------ Employee [FK] -----------
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //------------ ServiceOperatingLocation [FK] MAPPING TABLE -----------
        public ICollection<ServiceOperatingLocation> Services { get; set; } = new HashSet<ServiceOperatingLocation>();
    }
}
