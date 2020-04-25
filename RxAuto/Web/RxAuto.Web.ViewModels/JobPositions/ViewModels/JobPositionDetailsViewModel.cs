using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.JobPositions.ViewModels
{
    /// <summary>
    /// View model for JobPosition information with <c>Id</c> and <c>Name</c>.
    /// </summary>
    public class JobPositionDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Работна Позиция")]
        public string Name { get; set; }
    }
}
