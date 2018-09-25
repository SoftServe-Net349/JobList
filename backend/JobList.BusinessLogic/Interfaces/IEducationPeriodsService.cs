using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IEducationPeriodsService
    {
        Task<IEnumerable<EducationPeriodDTO>> GetAllEntitiesAsync();

        Task<EducationPeriodDTO> GetEntityByIdAsync(int id);

        Task<EducationPeriodDTO> CreateEntityAsync(EducationPeriodRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(EducationPeriodRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
