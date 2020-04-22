namespace RxAuto.Web.ViewModels.Phones.ViewModels
{
    /// <summary>
    /// View model for Phone delete confirmation data such as <c>Id</c>, <c>PhoneNumber</c> and <c>IsInternal</c>.
    /// </summary>
    public class DeletePhoneViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string IsInternal { get; set; }
    }
}
