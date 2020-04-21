namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    /// <summary>
    /// View model for Department information with <c>Id</c>, <c>Name</c>, <c>Email</c> and <c>Description</c>.
    /// </summary>
    public class DepartmentDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
