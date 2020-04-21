namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    /// <summary>
    /// View model for OperatingLocation information with <c>Id</c>, <c>Town</c> and <c>Address</c>.
    /// </summary>
    public class OperatingLocationDetailsViewModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
