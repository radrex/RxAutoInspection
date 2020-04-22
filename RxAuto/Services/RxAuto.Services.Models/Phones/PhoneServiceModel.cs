namespace RxAuto.Services.Models.Phones
{
    /// <summary>
    /// Service model for Phone information with <c>Id</c>, <c>PhoneNumber</c> and <c>IsInternal</c>.
    /// </summary>
    public class PhoneServiceModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string IsInternal { get; set; }
    }
}
