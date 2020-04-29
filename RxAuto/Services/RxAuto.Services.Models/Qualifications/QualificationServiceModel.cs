﻿namespace RxAuto.Services.Models.Qualifications
{
    /// <summary>
    /// Service model for Qualification information with <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class QualificationServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}