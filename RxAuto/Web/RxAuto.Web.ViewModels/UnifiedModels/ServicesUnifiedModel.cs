namespace RxAuto.Web.ViewModels.UnifiedModels
{
    using RxAuto.Web.ViewModels.Services.InputModels;
    using RxAuto.Web.ViewModels.Documents.InputModels;
    using RxAuto.Web.ViewModels.ServiceTypes.InputModels;
    using RxAuto.Web.ViewModels.VehicleTypes.InputModels;

    /// <summary>
    /// Input Unified Model, used to envelop 4 Input Models into a single one (<c>ServiceInputModel</c>, <c>ServiceTypeInputModel</c>, <c>VehicleTypeInputModel</c> and <c>DocumentInputModel</c>).
    /// <para>Passed in the main view, so partial views containing the 4 different Input Models can be used and rendered in different parts of the code for readability.</para>
    /// </summary>
    public class ServicesUnifiedModel
    {
        public ServiceInputModel ServiceInputModel { get; set; }
        public ServiceTypeInputModel ServiceTypeInputModel { get; set; }
        public VehicleTypeInputModel VehicleTypeInputModel { get; set; }
        public DocumentInputModel DocumentInputModel { get; set; }
    }
}
