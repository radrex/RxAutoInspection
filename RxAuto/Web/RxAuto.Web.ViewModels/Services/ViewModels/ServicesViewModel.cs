namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using System.Collections.Generic;

    public class ServicesViewModel
    {
        public IEnumerable<ServiceTypeInfoViewModel> ServiceTypes { get; set; }
    }
}
