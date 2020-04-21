namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    /// <summary>
    /// View model for OperatingLocation delete confirmation data such as <c>Id</c>, <c>Town</c> and <c>Address</c>.
    /// </summary>
    public class DeleteOperatingLocationViewModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
