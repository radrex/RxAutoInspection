namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Услуга")]
        public string Name { get; set; }

        [Display(Name = "Видимост в Подменю")]
        public string IsShownInSubMenu { get; set; }

        [Display(Name = "Тип Услуга")]
        public string ServiceType { get; set; }

        [Display(Name = "Категория")]
        public string VehicleType { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
