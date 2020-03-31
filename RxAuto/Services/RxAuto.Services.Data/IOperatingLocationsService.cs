namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Collections.Generic;

    /// <summary>
    /// Contains functionality methods concering <see cref="OperatingLocation"/> entity.
    /// </summary>
    public interface IOperatingLocationsService
    {
        IEnumerable<OperatingLocationsListingServiceModel> GetAll();
    }
}
