namespace RxAuto.Services.Models.ServiceTypes
{
    public class CreateServiceTypeServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsInDevelopment { get; set; }
    }
}
