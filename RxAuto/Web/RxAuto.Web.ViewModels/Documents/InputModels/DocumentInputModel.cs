namespace RxAuto.Web.ViewModels.Documents.InputModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering Document information from the user. 
    /// It includes <c>DocumentName</c> and <c>DocumentDescription</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class DocumentInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Name should be 5 to 20 characters long", MinimumLength = 5)]
        public string DocumentName { get; set; }

        [MaxLength(4000)]
        public string DocumentDescription { get; set; }
    }
}
