namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for ServiceType delete confirmation data such as <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>IsShownInMainMenu</c>.
    /// </summary>
    public class DeleteServiceTypeViewModel
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
