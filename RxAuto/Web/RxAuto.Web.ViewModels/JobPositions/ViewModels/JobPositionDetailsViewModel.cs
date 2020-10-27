using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.JobPositions.ViewModels
{
    public class JobPositionDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Работна Позиция")]
        public string Name { get; set; }
    }
}
