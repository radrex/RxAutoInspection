namespace RxAuto.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Reservations;
    using RxAuto.Web.ViewModels.Reservations.InputModels;
    using RxAuto.Web.ViewModels.Reservations.ViewModels;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = "User")]
    public class ReservationsController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IReservationsService reservationsService;

        //------------- CONSTRUCTORS --------------
        public ReservationsController(IReservationsService reservationsService)
        {
            this.reservationsService = reservationsService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //TODO: Add docs
        [HttpGet]
        public IActionResult MyReservations(int page = 1)
        {
            string username = this.User.Identity.Name;

            var viewModel = new ReservationsListingViewModel()
            {
                Reservations = this.reservationsService.AllForUser(username, ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new ReservationViewModel
                {
                    Id = x.Id,
                    ServiceType = x.ServiceType,
                    Service = x.Service,
                    IsActive = x.IsActive,
                    VehicleMake = x.VehicleMake,
                    VehicleModel = x.VehicleModel,
                    LicenseNumber = x.LicenseNumber,
                    PhoneNumber = x.PhoneNumber,
                    ReservationDateTime = x.ReservationDateTime,
                    Town = x.Town,
                    Address = x.Address,
                }),
            };


            int count = this.reservationsService.CountForUser(username);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //TODO: Add docs
        [HttpPost]
        public async Task<IActionResult> Cancel(string reservationId)
        {
            if (!this.reservationsService.Exists(reservationId))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            await this.reservationsService.EditAsync(reservationId);
            return this.RedirectToAction("MyReservations", "Reservations");
        }
    }
}
