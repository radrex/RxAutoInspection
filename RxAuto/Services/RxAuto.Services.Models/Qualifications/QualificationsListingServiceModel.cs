namespace RxAuto.Services.Models.Qualifications
{
    /// <summary>
    /// Service model for listing an Employee's <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class QualificationsListingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
