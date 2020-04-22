namespace RxAuto.Services.Models.ServiceTypes
{
    /// <summary>
    /// Service model for listing an ServiceType's <c>Id</c>, <c>Name</c> and <c>IsShownInMainMenu</c>.
    /// </summary>
    public class ServiceTypesListingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsShownInMainMenu { get; set; }
    }
}
