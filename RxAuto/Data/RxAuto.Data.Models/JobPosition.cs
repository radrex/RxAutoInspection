namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class JobPosition
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Name { get; set; }

        //------------ Employee [FK] -----------
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //------------ JobPositionQualification [FK] MAPPING TABLE -----------
        public ICollection<JobPositionQualification> Qualifications { get; set; } = new HashSet<JobPositionQualification>();
    }
}
