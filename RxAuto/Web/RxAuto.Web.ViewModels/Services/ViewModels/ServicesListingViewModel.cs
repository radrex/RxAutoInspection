namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using System.Collections.Generic;

    public class ServicesListingViewModel
    {
        public IEnumerable<ServiceViewModel> Services { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
