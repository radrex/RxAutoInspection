namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a Departments's information such as <c>Id</c>, <c>Name</c> and <c>Email</c>.
    /// </summary>
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
