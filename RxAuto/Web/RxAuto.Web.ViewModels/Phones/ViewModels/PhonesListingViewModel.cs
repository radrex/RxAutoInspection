namespace RxAuto.Web.ViewModels.Phones.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Phone information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class PhonesListingViewModel
    {
        public IEnumerable<PhoneViewModel> Phones { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
