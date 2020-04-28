namespace RxAuto.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using RxAuto.Services.Data;
    using RxAuto.Web.ViewModels.Services.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using System.Linq;
    using System.Threading.Tasks;

    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        //--------------- FIELDS ------------------
        private readonly IServiceTypesService serviceTypesService;

        //------------- CONSTRUCTORS --------------
        public MenuViewComponent(IServiceTypesService serviceTypesService)
        {
            this.serviceTypesService = serviceTypesService;
        }

        //--------------- METHODS -----------------
        public IViewComponentResult Invoke()
        {
            var viewModel = new ServicesViewModel
            {
                ServiceTypes = this.serviceTypesService
                                   .All()
                                   .Where(x => x.IsShownInMainMenu == true)
                                   .Select(x => new ServiceTypeInfoViewModel
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Description = x.Description,
                                       IsShownInMainMenu = x.IsShownInMainMenu == true ? "Видимо в Главното Меню" : "Скрито от Главното Меню",
                                   }),
            };

            return this.View(viewModel);
        }
    }
}
