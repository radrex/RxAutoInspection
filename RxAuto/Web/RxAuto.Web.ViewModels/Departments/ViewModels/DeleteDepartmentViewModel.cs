namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for Department delete confirmation data such as <c>Id</c>, <c>Name</c>, <c>Email</c> and <c>Description</c>.
    /// </summary>
    public class DeleteDepartmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Отдел")]
        public string Name { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
