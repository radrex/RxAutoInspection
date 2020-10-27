namespace RxAuto.Web.ViewModels.Documents.ViewModels
{
    using System.Collections.Generic;

    public class DocumentsListingViewModel
    {
        public IEnumerable<DocumentViewModel> Documents { get; set; }
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
