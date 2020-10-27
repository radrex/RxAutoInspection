namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    using System.Collections.Generic;

    public class OperatingLocationsListingViewModel
    {
        public IEnumerable<OperatingLocationViewModel> OperatingLocations { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
