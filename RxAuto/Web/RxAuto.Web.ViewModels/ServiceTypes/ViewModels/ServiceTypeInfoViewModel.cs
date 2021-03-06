﻿namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    using RxAuto.Web.ViewModels.Reservations.InputModels;
    using RxAuto.Web.ViewModels.Services.ViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ServiceTypeInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Тип Услуга")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Видимост в Главното Меню")]
        public string IsShownInMainMenu { get; set; }

        public string Url => $"/Services/{this.Name.Replace(' ', '-')}";

        public IEnumerable<ServiceInfoViewModel> Services { get; set; }

        //public ReservationInputModel ReservationInputModel { get; set; }

        //public IEnumerable<ReservationInputModel> ReservationInputModels { get; set; }
    }
}
