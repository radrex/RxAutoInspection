namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    using System.Collections.Generic;

    public class VehicleTypesListingViewModel
    {
        public IEnumerable<VehicleTypeViewModel> VehicleTypes { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
