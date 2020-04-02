namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    /// <summary>
    /// View model for Dropdown listing of a OperatingLocation's <c>Id</c>, <c>Town</c> and <c>Address</c>.
    /// </summary>
    public class OperatingLocationsDropdownViewModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
