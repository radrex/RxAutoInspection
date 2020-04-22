namespace RxAuto.Web.ViewModels.ServiceTypes.InputModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering ServiceType information from the user. 
    /// It includes <c>ServiceTypeName</c>, <c>ServiceTypeDescription</c> and <c>IsShownInMainMenu</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class ServiceTypeInputModel
    {
        public int Id { get; set; }

        [Display(Name = "Service Type")]
        [Required]
        [StringLength(100, ErrorMessage = "Name should be 3 to 20 characters long", MinimumLength = 3)]
        public string ServiceTypeName { get; set; }

        [MaxLength(4000)]
        public string ServiceTypeDescription { get; set; }

        public bool IsShownInMainMenu { get; set; }
    }
}
