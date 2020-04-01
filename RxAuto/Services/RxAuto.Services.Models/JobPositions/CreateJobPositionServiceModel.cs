namespace RxAuto.Services.Models.JobPositions
{
    using RxAuto.Services.Models.Qualifications;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for Creating a JobPosition with <c>Name</c> and IEnumerable&lt;<see cref="QualificationsDropdownServiceModel"/>&gt;.
    /// <para>Each <see cref="QualificationsDropdownServiceModel"/> contains Qualification's <c>Id</c> and <c>Name</c> properties.</para>
    /// </summary>
    public class CreateJobPositionServiceModel
    {
        public string Name { get; set; }
        public IEnumerable<QualificationsDropdownServiceModel> Qualifications { get; set; }
    }
}
