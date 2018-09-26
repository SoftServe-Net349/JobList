using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IVacanciesService
    {
        Task<IEnumerable<VacancyDTO>> GetAllEntitiesAsync();

        Task<VacancyDTO> GetEntityByIdAsync(int id);

        Task<VacancyDTO> CreateEntityAsync(VacancyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(VacancyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
