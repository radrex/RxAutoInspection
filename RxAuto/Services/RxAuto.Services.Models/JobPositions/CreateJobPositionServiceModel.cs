namespace RxAuto.Services.Models.JobPositions
{
    using RxAuto.Services.Models.Qualifications;
    using System.Collections.Generic;

    public class CreateJobPositionServiceModel
    {
        public string Name { get; set; }
        public IEnumerable<QualificationsDropdownServiceModel> Qualifications { get; set; }
    }
}
