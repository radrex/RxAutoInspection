namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Service information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class ServicesListingViewModel
    {
        public IEnumerable<ServiceViewModel> Services { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
