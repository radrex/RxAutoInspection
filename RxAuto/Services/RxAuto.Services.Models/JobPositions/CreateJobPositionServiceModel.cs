namespace RxAuto.Services.Models.JobPositions
{
    using RxAuto.Services.Models.Qualifications;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for Creating a JobPosition with <c>Name</c> and IEnumerable&lt;<see cref="QualificationsListingServiceModel"/>&gt; collection properties.
    /// <para>Each <see cref="QualificationsListingServiceModel"/> contains Qualification <c>Id</c> and <c>Name</c> properties.</para>
    /// </summary>
    public class CreateJobPositionServiceModel
    {
        public string Name { get; set; }
        public IEnumerable<QualificationsListingServiceModel> Qualifications { get; set; }
    }
}
