﻿namespace RxAuto.Web.ViewModels.Employees.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EmployeeViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Име")]
        public string FullName { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Работна Локация")]
        public string OperatingLocation { get; set; }

        [Display(Name = "Работна Позиция")]
        public string JobPosition { get; set; }
    }
}
