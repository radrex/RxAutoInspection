namespace RxAuto.Web.ViewModels.Reservations.ViewModels
{
    using System.Collections.Generic;

    public class ReservationsListingViewModel
    {
        public IEnumerable<ReservationViewModel> Reservations { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
