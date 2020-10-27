namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    using System.Collections.Generic;

    public class ServiceTypesListingViewModel
    {
        public IEnumerable<ServiceTypeViewModel> ServiceTypes { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
