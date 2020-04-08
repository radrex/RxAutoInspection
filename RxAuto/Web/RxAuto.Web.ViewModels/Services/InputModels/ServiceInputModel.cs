namespace RxAuto.Web.ViewModels.Services.InputModels
{
    using RxAuto.Web.ViewModels.Documents.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using RxAuto.Web.ViewModels.VehicleTypes.ViewModels;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    /// <summary>
    /// Input model for entering Service information from the user. 
    /// It includes <c>ServiceTypeId</c>, <c>ServiceName</c>, <c>ServiceDescription</c>, <c>IsShownInSubMenu</c>, <c>Price</c>, <c>OperatingLocationIds</c>, <c>VehicleTypeId</c> and <c>DocumentIds</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class ServiceInputModel
    {
        //----------------------------- SERVICE TYPES ---------------------------------
        // For Id passed from <select>
        [Display(Name = "Service Type")]
        public int ServiceTypeId { get; set; }
        public IEnumerable<ServiceTypesDropdownViewModel> ServiceTypes { get; set; }

        //----------------------------- SERVICE INFO ----------------------------------
        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "Please enter Service Type name")]
        [StringLength(100, ErrorMessage = "Name should be 5 to 100 characters long", MinimumLength = 5)]
        public string ServiceName { get; set; }

        [Display(Name = "Service Description")]
        [MaxLength(4000)]
        public string ServiceDescription { get; set; }

        public bool IsShownInSubMenu { get; set; }

        // TODO: Price regex validation not working properly
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")] no option to change culture info...
        [Required]
        [Display(Name = "Price Tag", Prompt = "0.00lv")] // Prompt watermark/placeholder not working for decimal with asp tag helpers
        //[RegularExpression(@"\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})?", ErrorMessage = "Invalid price.")]
        [Range(5, 200000)]
        public decimal Price { get; set; }

        //----------------------------- LOCATIONS -------------------------------------
        // For multiple Id's passed from <select>
        [Display(Name = "Operating Locations")]
        public int[] OperatingLocationIds { get; set; }
        public IEnumerable<OperatingLocationsDropdownViewModel> OperatingLocations { get; set; }

        //----------------------------- VEHICLE TYPES ---------------------------------
        // For Id passed from <select>
        [Display(Name = "Vehicle Type")]
        public int VehicleTypeId { get; set; }
        public IEnumerable<VehicleTypesDropdownViewModel> VehicleTypes { get; set; }

        //----------------------------- DOCUMENTS -------------------------------------
        // For multiple Id's passed from <select>
        [Display(Name = "Documents")]
        public int[] DocumentIds { get; set; }
        public IEnumerable<DocumentsDropdownViewModel> Documents { get; set; }
    }
}
