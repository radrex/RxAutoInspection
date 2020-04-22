namespace RxAuto.Services.Models.Phones
{
    /// <summary>
    /// Service model for listing an Phone's <c>Id</c>, <c>PhoneNumber</c> and <c>IsInternal</c>.
    /// </summary>
    public class PhonesListingServiceModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string IsInternal { get; set; }
    }
}
