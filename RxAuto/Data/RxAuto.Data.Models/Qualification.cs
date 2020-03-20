namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.MediaInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Qualification
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        //------------ JobPositionQualification [FK] MAPPING TABLE -----------
        public virtual ICollection<JobPositionQualification> JobPositions { get; set; } = new HashSet<JobPositionQualification>();

        //------------ EmployeeQualification [FK] MAPPING TABLE -----------
        public virtual ICollection<EmployeeQualification> Employees { get; set; } = new HashSet<EmployeeQualification>();
    }
}
