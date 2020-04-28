namespace RxAuto.Web.ViewModels.Reservations.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    //TODO: Add docs
    public class ReservationInputModel
    {
        public int Id { get; set; }

        [Display(Name = "Марка автомобил", Prompt = "Марка автомобил")]
        public string VehicleMake { get; set; }

        [Display(Name = "Модел на автомобил", Prompt = "Модел на автомобил")]
        public string VehicleModel { get; set; }

        [Required]
        //TODO: Add regex validation
        [Display(Name = "Регистрационен номер", Prompt = "Регистрационен номер")]
        public string LicenseNumber { get; set; }

        [Required]
        //TODO: Validate DateTime
        public DateTime ReservationDateTime { get; set; }

        [Display(Name = "Телефон", Prompt = "Телефон")]
        [Required(ErrorMessage = "Моля въведете Телефон")]
        [RegularExpression(@"^([+]?359)|0?(|-| )8[789]\d{1}(|-| )\d{3}(|-| )\d{3}$", ErrorMessage = "Невалиден Телефон")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }
    }
}
