﻿namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    /// <summary>
    /// View model for ServiceType delete confirmation data such as <c>Id</c>, <c>Name</c>, <c>Description</c> and <c>IsShownInMainMenu</c>.
    /// </summary>
    public class DeleteServiceTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsShownInMainMenu { get; set; }
    }
}
