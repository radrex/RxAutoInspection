namespace RxAuto.Web.ViewModels.OperatingLocations.ViewModels
{
    /// <summary>
    /// View model for listing a OperatingLocation's information such as <c>Id</c> and <c>Name</c>.
    /// </summary>
    public class OperatingLocationViewModel
    {
        public int Id { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        // TODO: Add departments, emloyees, services to view foreach operatingLocation
    }
}
