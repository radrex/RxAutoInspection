namespace RxAuto.Web.ViewModels.Services.InputModels
{
    using RxAuto.Web.ViewModels.Documents.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using RxAuto.Web.ViewModels.VehicleTypes.ViewModels;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class ServiceInputModel
    {
        public int Id { get; set; }

        //----------------------------- SERVICE TYPES ---------------------------------
        // For Id passed from <select>
        [Display(Name = "Тип Услуга", Prompt = "Тип Услуга")]
        public int ServiceTypeId { get; set; }
        public IEnumerable<ServiceTypesDropdownViewModel> ServiceTypes { get; set; }

        //----------------------------- SERVICE INFO ----------------------------------
        [Display(Name = "Услуга", Prompt = "Услуга")]
        [Required(ErrorMessage = "Моля въведете Услуга")]
        [StringLength(100, ErrorMessage = "Услугата трябва да е междъу 5 и 100 символа", MinimumLength = 5)]
        public string ServiceName { get; set; }

        [Display(Name = "Описание", Prompt = "Описание")]
        [MaxLength(4000)]
        public string ServiceDescription { get; set; }

        public bool IsShownInSubMenu { get; set; }

        // TODO: Price regex validation tweak
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")] no option to change culture info...
        [Required(ErrorMessage = "Моля въведете Цена")]
        [Display(Name = "Цена", Prompt = "0.00lv")] // Prompt watermark/placeholder not working for decimal with asp tag helpers
        //[RegularExpression(@"\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})?", ErrorMessage = "Invalid price.")]
        [RegularExpression(@"^([0-9]{0,6}((.)[0-9]{0,2}))$", ErrorMessage = "Invalid price.")]
        [Range(5, 200000)]
        public decimal Price { get; set; }

        //----------------------------- LOCATIONS -------------------------------------
        // For multiple Id's passed from <select>
        [Display(Name = "Избери работни позиции")]
        public int[] OperatingLocationIds { get; set; }
        public IEnumerable<OperatingLocationsDropdownViewModel> OperatingLocations { get; set; }

        //----------------------------- VEHICLE TYPES ---------------------------------
        // For Id passed from <select>
        [Display(Name = "Избери категория")]
        public int VehicleTypeId { get; set; }
        public IEnumerable<VehicleTypesDropdownViewModel> VehicleTypes { get; set; }

        //----------------------------- DOCUMENTS -------------------------------------
        // For multiple Id's passed from <select>
        [Display(Name = "Избери необходими документи")]
        public int[] DocumentIds { get; set; }
        public IEnumerable<DocumentsDropdownViewModel> Documents { get; set; }
    }
}
