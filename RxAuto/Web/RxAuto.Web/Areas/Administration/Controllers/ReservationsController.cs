namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Web.ViewModels.Reservations.ViewModels;

    using RxAuto.Services.Data;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
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

        //----------------------- LISTING FOR RESERVATIONS --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Reservations/All/{page}</para>
        /// <para>Returns a View with Reservations listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with Reservations listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new ReservationsListingViewModel()
            {
                Reservations = this.reservationsService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new ReservationViewModel 
                {
                    Id = x.Id,
                    ServiceType = x.ServiceType,
                    Service = x.Service,
                    IsActive = x.IsActive,
                    VehicleMake = x.VehicleMake,
                    VehicleModel = x.VehicleModel,
                    LicenseNumber = x.LicenseNumber,
                    PhoneNumber = x.PhoneNumber,
                    ReservationDateTime = x.ReservationDateTime
                }),
            };

            int count = this.reservationsService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }
    }
}
