namespace RxAuto.Services.Models.ServiceTypes
{
    using RxAuto.Services.Models.Services;
    using System.Collections.Generic;

    public class ServiceTypeInfoServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShownInMainMenu { get; set; }
        public IEnumerable<ServiceInfoServiceModel> Services { get; set; }
    }
}
