namespace RxAuto.Web.ViewModels.JobPositions.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing JobPosition information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class JobPositionsListingViewModel
    {
        public IEnumerable<JobPositionViewModel> JobPositions { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
