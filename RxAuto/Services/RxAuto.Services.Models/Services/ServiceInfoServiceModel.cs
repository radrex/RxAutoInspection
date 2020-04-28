namespace RxAuto.Services.Models.Services
{
    using RxAuto.Services.Models.Documents;
    using System.Collections.Generic;

    //TODO:Add docs
    public class ServiceInfoServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<DocumentInfoServiceModel> Documents { get; set; }
    }
}
