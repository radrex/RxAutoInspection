namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Phones;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains functionality methods concering <see cref="Phone"/> entity.
    /// </summary>
    public interface IPhonesService
    {
        Task<int> CreateAsync(CreatePhoneServiceModel model);
        IEnumerable<PhonesListingServiceModel> GetAll();
    }
}
