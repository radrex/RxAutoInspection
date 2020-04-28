namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Services information.
    /// </summary>
    public class ServicesViewModel
    {
        public IEnumerable<ServiceTypeInfoViewModel> ServiceTypes { get; set; }
    }
}
