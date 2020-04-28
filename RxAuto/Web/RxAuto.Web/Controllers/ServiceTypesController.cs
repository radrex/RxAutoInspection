namespace RxAuto.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.ServiceTypes;
    using RxAuto.Web.ViewModels.Documents.ViewModels;
    using RxAuto.Web.ViewModels.Services.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using System.Linq;

    public class ServiceTypesController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IServiceTypesService serviceTypesService;

        //------------- CONSTRUCTORS --------------
        public ServiceTypesController(IServiceTypesService serviceTypesService)
        {
            this.serviceTypesService = serviceTypesService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        // TODO: Add docs
        [HttpGet]
        public IActionResult ByName(string name)
        {
            ServiceTypeInfoServiceModel serviceType = this.serviceTypesService.GetByNamePreview(name);
            if (serviceType == null)
            {
                return this.NotFound();
            }

            var model = new ServiceTypeInfoViewModel
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description,
                IsShownInMainMenu = serviceType.IsShownInMainMenu == true ? "Видимо в Главното Меню" : "Скрито от Главното Меню",
                Services = serviceType.Services.Select(x => new ServiceInfoViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    VehicleType = x.VehicleType,
                    Price = x.Price,
                    Documents = x.Documents.Select(x => new DocumentInfoViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                    })
                }),

                //ReservationInputModel = serviceType. // za vseki input model trqbva da imam id na service-a ?

                
            };

            return this.View(model);
        }
    }
}
