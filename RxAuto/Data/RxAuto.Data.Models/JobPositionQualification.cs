namespace RxAuto.Data.Models
{
    public class JobPositionQualification
    {
        //------------ JobPosition [FK] -----------
        public int JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; }

        //------------ Qualification [FK] -----------
        public int QualificationId { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}
