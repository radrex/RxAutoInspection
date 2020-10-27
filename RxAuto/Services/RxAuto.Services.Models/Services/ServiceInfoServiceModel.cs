namespace RxAuto.Services.Models.Services
{
    using RxAuto.Services.Models.Documents;
    using System.Collections.Generic;

    public class ServiceInfoServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<DocumentInfoServiceModel> Documents { get; set; }
    }
}
