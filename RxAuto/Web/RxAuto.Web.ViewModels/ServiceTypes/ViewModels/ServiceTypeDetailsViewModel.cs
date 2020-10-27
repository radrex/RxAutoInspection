namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceTypeDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Тип Услуга")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Видимост в Главното Меню")]
        public string IsShownInMainMenu { get; set; }
    }
}
