namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing OperatingLocation information.
    /// </summary>
    public class OperatingLocationsViewModel
    {
        public IEnumerable<OperatingLocationInfoViewModel> OperatingLocations { get; set; }
    }
}
