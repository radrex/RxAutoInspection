namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class Qualification
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //------------ JobPositionQualification [FK] MAPPING TABLE -----------
        public ICollection<JobPositionQualification> JobPositions { get; set; } = new HashSet<JobPositionQualification>();

        //------------ EmployeeQualification [FK] MAPPING TABLE -----------
        public ICollection<EmployeeQualification> Employees { get; set; } = new HashSet<EmployeeQualification>();
    }
}
