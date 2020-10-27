namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using System.ComponentModel.DataAnnotations;

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
