namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Отдел")]
        public string Name { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }
    }
}
