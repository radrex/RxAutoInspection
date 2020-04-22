namespace RxAuto.Services.Models.ServiceTypes
{
    /// <summary>
    /// Service model for ServiceType edit information with <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>IsShownInMainMenu</c>.
    /// </summary>
    public class EditServiceTypeServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShownInMainMenu { get; set; }
    }
}
