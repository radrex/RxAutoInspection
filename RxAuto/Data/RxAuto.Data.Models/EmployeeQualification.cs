namespace RxAuto.Data.Models
{
    public class EmployeeQualification
    {
        //------------ Employee [FK] -----------
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //------------ Qualification [FK] -----------
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }
    }
}
