namespace RxAuto.Web.ViewModels.Reservations.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a Service's information such as <c>Id</c>, <c>Service</c>, <c>VehicleMake</c>, <c>VehicleModel</c>, <c>LicenseNumber</c>, <c>PhoneNumber</c> and <c>ReservationDateTime</c>.
    /// </summary>
    public class ReservationViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Резервация")]
        public string IsActive { get; set; }

        [Display(Name = "Тип Услуга")]
        public string ServiceType { get; set; }

        [Display(Name = "Услуга")]
        public string Service { get; set; }

        [Display(Name = "Марка")]
        public string VehicleMake { get; set; }

        [Display(Name = "Модел")]
        public string VehicleModel { get; set; }

        [Display(Name = "Регистрационен Номер")]
        public string LicenseNumber { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Дата и час")]
        public string ReservationDateTime { get; set; }
    }
}
