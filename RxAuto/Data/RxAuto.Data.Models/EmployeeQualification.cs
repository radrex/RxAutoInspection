namespace RxAuto.Data.Models
{
    public class EmployeeQualification
    {
        //------------ Employee [FK] -----------
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        //------------ Qualification [FK] -----------
        public int QualificationId { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}
