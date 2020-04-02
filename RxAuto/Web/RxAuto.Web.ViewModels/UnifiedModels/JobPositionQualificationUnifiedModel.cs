namespace RxAuto.Web.ViewModels.UnifiedModels
{
    using RxAuto.Web.ViewModels.JobPositions.InputModels;
    using RxAuto.Web.ViewModels.Qualifications.InputModels;

    /// <summary>
    /// Input Unified Model, used to envelop 2 Input Models into a single one (<c>JobPositionInputModel</c> and <c>QualificationInputModel</c>).
    /// <para>Passed in the main view, so partial views containing the 2 different Input Models can be used and rendered in different parts of the code for readability.</para>
    /// </summary>
    public class JobPositionQualificationUnifiedModel
    {
        public JobPositionInputModel JobPositionInputModel { get; set; }
        public QualificationInputModel QualificationInputModel { get; set; }
    }
}
