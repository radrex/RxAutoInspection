namespace RxAuto.Web.ViewModels.UnifiedModels
{
    using RxAuto.Web.ViewModels.Phones.InputModels;
    using RxAuto.Web.ViewModels.Departments.InputModels;

    /// <summary>
    /// Input Unified Model, used to envelop 2 Input Models into a single one (<c>DepartmentInputModel</c> and <c>PhoneInputModel</c>).
    /// <para>Passed in the main view, so partial views containing the 2 different Input Models can be used and rendered in different parts of the code for readability.</para>
    /// </summary>
    public class DepartmentPhoneUnifiedModel
    {
        public DepartmentInputModel DepartmentInputModel { get; set; }
        public PhoneInputModel PhoneInputModel { get; set; }
    }
}
