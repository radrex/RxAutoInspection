namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a Service's information such as <c>Id</c>, <c>Name</c>, <c>IsShownInSubMenu</c>, <c>ServiceType</c>, <c>VehicleType</c> and <c>Price</c>.
    /// </summary>
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Service Name")]
        public string Name { get; set; }

        public string IsShownInSubMenu { get; set; }
        public string ServiceType { get; set; }
        public string VehicleType { get; set; }
        public decimal Price { get; set; }
    }
}
