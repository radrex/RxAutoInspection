namespace RxAuto.Web.ViewModels.Qualifications.ViewModels
{
    using System.Collections.Generic;

    public class QualificationsListingViewModel
    {
        public IEnumerable<QualificationViewModel> Qualifications { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
