namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.JobPositions;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains functionality methods concering <see cref="JobPosition"/> entity.
    /// </summary>
    public interface IJobPositionsService
    {
        Task<int> CreateAsync(CreateJobPositionServiceModel model);
        IEnumerable<JobPositionsDropdownServiceModel> GetAll();
    }
}
