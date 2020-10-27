namespace RxAuto.Services.Models.ServiceTypes
{
    public class EditServiceTypeServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShownInMainMenu { get; set; }
    }
}
