namespace RxAuto.Web.ViewModels.Documents.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// View model for listing Document information, <c>CurrentPage</c> and <c>PagesCount</c>.
    /// </summary>
    public class DocumentsListingViewModel
    {
        public IEnumerable<DocumentViewModel> Documents { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
