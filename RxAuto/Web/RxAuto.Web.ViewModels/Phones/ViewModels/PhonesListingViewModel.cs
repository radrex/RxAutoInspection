namespace RxAuto.Web.ViewModels.Phones.ViewModels
{
    using System.Collections.Generic;

    public class PhonesListingViewModel
    {
        public IEnumerable<PhoneViewModel> Phones { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
