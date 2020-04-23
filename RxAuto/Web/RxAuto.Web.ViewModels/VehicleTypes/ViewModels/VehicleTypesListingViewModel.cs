namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing VehicleType information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class VehicleTypesListingViewModel
    {
        public IEnumerable<VehicleTypeViewModel> VehicleTypes { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
