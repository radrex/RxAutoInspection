namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a Service's information such as <c>Id</c>, <c>Name</c>, <c>IsShownInSubMenu</c>, <c>ServiceType</c>, <c>VehicleType</c> and <c>Price</c>.
    /// </summary>
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
