namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DepartmentInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Отдел")]
        public string Name { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        // TODO: Add ImageUrl

        [Display(Name = "Телефони")]
        public IEnumerable<PhoneViewModel> Phones { get; set; }
    }
}
