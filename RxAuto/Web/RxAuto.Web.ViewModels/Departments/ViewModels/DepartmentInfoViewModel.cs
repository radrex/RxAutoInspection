namespace RxAuto.Web.ViewModels.Departments.ViewModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a Department's information such as <c>Id</c>, <c>Name</c>, <c>Email</c> and a collection of <c>Phones</c>.
    /// </summary>
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
