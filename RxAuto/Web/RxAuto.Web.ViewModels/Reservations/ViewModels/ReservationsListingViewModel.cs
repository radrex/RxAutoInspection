namespace RxAuto.Web.ViewModels.Reservations.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Reservation information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class ReservationsListingViewModel
    {
        public IEnumerable<ReservationViewModel> Reservations { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
