﻿namespace RxAuto.Web.ViewModels.ServiceTypes.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceTypeInputModel
    {
        public int Id { get; set; }

        [Display(Name = "Тип Услуга", Prompt = "Тип Услуга")]
        [Required(ErrorMessage = "Моля въведете Тип Услуга")]
        [StringLength(100, ErrorMessage = "Name should be 3 to 20 characters long", MinimumLength = 3)]
        public string ServiceTypeName { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string ServiceTypeDescription { get; set; }

        public bool IsShownInMainMenu { get; set; }
    }
}
