namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Тип Услуга")]
        public string Name { get; set; }

        [Display(Name = "Видимост в Главното Меню")]
        public string IsShownInMainMenu { get; set; }
    }
}
