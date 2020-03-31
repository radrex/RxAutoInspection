namespace RxAuto.Web.ViewModels.UnifiedModels
{
    using RxAuto.Web.ViewModels.JobPositions.InputModels;
    using RxAuto.Web.ViewModels.Qualifications.InputModels;

    public class JobPositionQualificationUnifiedModel
    {
        public JobPositionInputModel JobPositionInputModel { get; set; }
        public QualificationInputModel QualificationInputModel { get; set; }
    }
}
