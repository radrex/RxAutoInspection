namespace RxAuto.Web.ViewModels.VehicleTypes.ViewModels
{
    /// <summary>
    /// View model for Dropdown listing of a VehicleType's <c>Id</c>, <c>Category</c> and <c>Name</c>.
    /// </summary>
    public class VehicleTypesDropdownViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
    }
}
