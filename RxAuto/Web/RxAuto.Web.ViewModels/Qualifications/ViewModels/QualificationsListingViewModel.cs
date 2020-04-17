namespace RxAuto.Web.ViewModels.Qualifications.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Qualification information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class QualificationsListingViewModel
    {
        public IEnumerable<QualificationViewModel> Qualifications { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
