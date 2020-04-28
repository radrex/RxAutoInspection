namespace RxAuto.Web.ViewModels.Services.ViewModels
{
    using RxAuto.Web.ViewModels.Documents.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ServiceInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Услуга")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string VehicleType { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        public IEnumerable<DocumentInfoViewModel> Documents { get; set; }
    }
}
