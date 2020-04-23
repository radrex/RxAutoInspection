namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    /// <summary>
    /// View model for JobPosition delete confirmation data such as <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>VehicleCategory</c>.
    /// </summary>
    public class DeleteVehicleTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VehicleCategory { get; set; }
    }
}
