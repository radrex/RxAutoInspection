namespace RxAuto.Web.ViewModels.JobPositions.ViewModels
{
    using System.Collections.Generic;

    public class JobPositionsListingViewModel
    {
        public IEnumerable<JobPositionViewModel> JobPositions { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
