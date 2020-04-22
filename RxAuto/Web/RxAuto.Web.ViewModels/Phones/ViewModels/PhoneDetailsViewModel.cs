namespace RxAuto.Web.ViewModels.Phones.ViewModels
{
    /// <summary>
    /// View model for JobPosition information with <c>Id</c>, <c>PhoneNumber</c> and <c>IsInternal</c>.
    /// </summary>
    public class PhoneDetailsViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string IsInternal { get; set; }
    }
}
