namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing ServiceType information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class ServiceTypesListingViewModel
    {
        public IEnumerable<ServiceTypeViewModel> ServiceTypes { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
