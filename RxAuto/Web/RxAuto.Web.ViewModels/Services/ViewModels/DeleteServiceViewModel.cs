namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for Service delete confirmation data such as <c>Id</c>, <c>Name</c>, <c>Price</c>, <c>Description</c>, <c>ServiceType</c>, <c>VehicleType</c> and <c>IsShownInSubMenu</c>.
    /// </summary>
    public class DeleteServiceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Услуга")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Тип Услуга")]
        public string ServiceType { get; set; }

        [Display(Name = "Категория")]
        public string VehicleType { get; set; }

        [Display(Name = "Видимост в Подменю")]
        public string IsShownInSubMenu { get; set; }
    }
}
