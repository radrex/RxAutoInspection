namespace RxAuto.Web.ViewModels.Reservations.InputModels
{
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ReservationInputModel
    {
        [Display(Name = "Марка автомобил", Prompt = "Марка автомобил")]
        [MaxLength(30)]
        public string VehicleMake { get; set; }

        [Display(Name = "Модел на автомобил", Prompt = "Модел на автомобил")]
        [MaxLength(30)]
        public string VehicleModel { get; set; }

        [Required]
        //TODO: Add regex validation
        [Display(Name = "Регистрационен номер", Prompt = "Регистрационен номер")]
        [MaxLength(10)]
        public string LicenseNumber { get; set; }

        //TODO: Validate DateTime
        [Display(Name = "Дата и час")]
        public string ReservationDateTime { get; set; }

        [Display(Name = "Телефон", Prompt = "Телефон")]
        [Required(ErrorMessage = "Моля въведете Телефон")]
        [RegularExpression(@"^([+]?359)|0?(|-| )8[789]\d{1}(|-| )\d{3}(|-| )\d{3}$", ErrorMessage = "Невалиден Телефон")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public int ServiceId { get; set; }

        [Display(Name = "Работна Локация", Prompt = "Работна Локация")]
        [Required(ErrorMessage = "Моля въвдете Работна Локация")]
        [Range(10, int.MaxValue)]
        public int OperatingLocationId { get; set; }
        public IEnumerable<OperatingLocationsDropdownViewModel> OperatingLocations { get; set; }
    }
}
