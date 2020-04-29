﻿namespace RxAuto.Web.ViewModels.Phones.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a Phone's information such as <c>Id</c>, <c>PhoneNumber</c> and <c>IsInternal</c>.
    /// </summary>
    public class PhoneViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Публичност")]
        public string IsInternal { get; set; }

        // TODO: Add departments to view foreach phone
    }
}