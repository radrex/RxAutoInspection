namespace RxAuto.Web.ViewModels.UnifiedModels
{
    using RxAuto.Web.ViewModels.Phones.InputModels;
    using RxAuto.Web.ViewModels.Departments.InputModels;

    public class DepartmentPhoneUnifiedModel
    {
        public DepartmentInputModel DepartmentInputModel { get; set; }
        public PhoneInputModel PhoneInputModel { get; set; }
    }
}
