namespace RxAuto.Web.ViewModels.Employees.ViewModels
{
    /// <summary>
    /// View model for Employee delete confirmation data such as <c>Id</c>, <c>FullName</c>, <c>OperatingLocation</c> and <c>JobPosition</c>.
    /// </summary>
    public class DeleteEmployeeViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string OperatingLocation { get; set; }
        public string JobPosition { get; set; }
    }
}
