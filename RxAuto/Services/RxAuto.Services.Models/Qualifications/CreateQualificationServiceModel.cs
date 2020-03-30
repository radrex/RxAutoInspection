namespace RxAuto.Services.Models.Qualifications
{
    /// <summary>
    /// Service model for Creating a Qualification with <c>Name</c> and <c>Description</c> properties.
    /// </summary>
    public class CreateQualificationServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
