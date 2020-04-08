namespace RxAuto.Services.Models.ServiceTypes
{
    /// <summary>
    /// Service model for Creating a ServiceType with <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class CreateServiceTypeServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsInDevelopment { get; set; }
    }
}
