namespace RxAuto.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Reservations;
    using RxAuto.Services.Models.ServiceTypes;
    using RxAuto.Web.ViewModels.Documents.ViewModels;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;
    using RxAuto.Web.ViewModels.Reservations.InputModels;
    using RxAuto.Web.ViewModels.Services.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public class ServiceTypesController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IServiceTypesService serviceTypesService;
        private readonly IReservationsService reservationsService;
        private readonly IOperatingLocationsService operatingLocationsService;

        //------------- CONSTRUCTORS --------------
        public ServiceTypesController(IServiceTypesService serviceTypesService, IReservationsService reservationsService, IOperatingLocationsService operatingLocationsService)
        {
            this.serviceTypesService = serviceTypesService;
            this.reservationsService = reservationsService;
            this.operatingLocationsService = operatingLocationsService;
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
                //ReservationInputModel = new ReservationInputModel {}
                //ReservationInputModels = new List<ReservationInputModel>(),
            };

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ByName(ReservationInputModel model)
        {
            string username = this.User.Identity.Name;

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
                OperatingLocationId = model.OperatingLocationId,
                Username = username,
            };

            await this.reservationsService.CreateAsync(reservation);

            if (this.User.IsInRole("User"))
            {
                return this.RedirectToAction("MyReservations", "Reservations");
            }

            return this.RedirectToAction("ByName");
        }
    }
}
