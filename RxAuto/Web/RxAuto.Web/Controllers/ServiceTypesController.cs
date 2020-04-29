namespace RxAuto.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Reservations;
    using RxAuto.Services.Models.ServiceTypes;
    using RxAuto.Web.ViewModels.Documents.ViewModels;
    using RxAuto.Web.ViewModels.Reservations.InputModels;
    using RxAuto.Web.ViewModels.Services.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public class ServiceTypesController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IServiceTypesService serviceTypesService;
        private readonly IReservationsService reservationsService;

        //------------- CONSTRUCTORS --------------
        public ServiceTypesController(IServiceTypesService serviceTypesService, IReservationsService reservationsService)
        {
            this.serviceTypesService = serviceTypesService;
            this.reservationsService = reservationsService;
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ByName(ReservationInputModel model)
        {
            string username = this.User.Identity.Name;
            var serviceId = this.ViewData["ServiceId"]; // figure out how to pass the service from the view to the controller
            ;

            if (!this.ModelState.IsValid)
            {
                return this.PartialView("~/Views/ServiceTypes/_ReservationModalForm.cshtml", model);
            }

            var reservation = new CreateReservationServiceModel
            {
                VehicleMake = model.VehicleMake,
                VehicleModel = model.VehicleModel,
                LicenseNumber = model.LicenseNumber,
                ReservationDateTime = DateTime.ParseExact(model.ReservationDateTime, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture),
                PhoneNumber = model.PhoneNumber,
                ServiceId = model.ServiceId,
                Username = username,
            };

            await this.reservationsService.CreateAsync(reservation);
            return this.RedirectToAction("Create");
        }
    }
}
