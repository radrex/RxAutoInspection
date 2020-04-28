namespace RxAuto.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RxAuto.Services.Data;
    using RxAuto.Web.ViewModels.Services.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using System.Linq;

    public class ServicesController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IServiceTypesService serviceTypesService;

        //------------- CONSTRUCTORS --------------
        public ServicesController(IServiceTypesService serviceTypesService)
        {
            this.serviceTypesService = serviceTypesService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Services/Preview/</para>
        /// <para>Shows an Admin Preview Page for every ServiceType</para>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Preview()
        {
            var viewModel = new ServicesViewModel
            {
                ServiceTypes = this.serviceTypesService.All().Select(x => new ServiceTypeInfoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsShownInMainMenu = x.IsShownInMainMenu == true ? "Видимо в Главното Меню" : "Скрито от Главното Меню",
                    //Fill reservation input model
                    //ReservationInputModel = 
                }),
            };

            return this.View(viewModel);
        }
    }
}
