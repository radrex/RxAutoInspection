namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Departments;

    using System.Threading.Tasks;

    /// <summary>
    /// Contains functionality methods concering <see cref="Department"/> entity.
    /// </summary>
    public interface IDepartmentsService
    {
        Task<int> CreateAsync(CreateDepartmentServiceModel model);
    }
}
