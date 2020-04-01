namespace RxAuto.Services.Data
{
    using RxAuto.Data.Models;
    using RxAuto.Services.Models.Qualifications;

    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Contains functionality methods concering <see cref="Qualification"/> entity.
    /// </summary>
    public interface IQualificationsService
    {
        Task<int> CreateAsync(CreateQualificationServiceModel model);
        IEnumerable<QualificationsDropdownServiceModel> GetAll();
        QualificationsDropdownServiceModel GetById(int id);
        QualificationsDropdownServiceModel GetByName(string name);
    }
}
