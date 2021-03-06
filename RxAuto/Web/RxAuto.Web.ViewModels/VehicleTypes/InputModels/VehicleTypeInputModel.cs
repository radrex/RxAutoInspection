﻿namespace RxAuto.Web.ViewModels.VehicleTypes.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class VehicleTypeInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(50, ErrorMessage = "Името на категорията трябва да е между 5 и 50 символа", MinimumLength = 5)]
        [Display(Name = "Име на категория", Prompt = "Име на категория")]
        public string VehicleTypeName { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string VehicleTypeDescription { get; set; }

        [Display(Name = "Категория", Prompt = "Категория")]
        [Range(1, int.MaxValue)]
        public int VehicleCategoryId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
    }

    public enum VehicleCategory
    {
        M1 = 1,
        M2 = 2,
        M3 = 3,

        N1 = 4,
        N2 = 5,
        N3 = 6,

        O1 = 7,
        O2 = 8,
        O3 = 9,
        O4 = 10,

        L1 = 11,
        L1e = 12,
        L2 = 13,
        L2e = 14,
        L3 = 15,
        L3e = 16,
        L4 = 17,
        L4e = 18,
        L5 = 19,
        L5e = 20,
        L6 = 21,
        L6e = 22,
        L7 = 23,
        L7e = 24,
    }
}
