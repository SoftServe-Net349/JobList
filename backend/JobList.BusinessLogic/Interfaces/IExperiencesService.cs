using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IExperiencesService
    {
        Task<IEnumerable<ExperienceDTO>> GetAllEntitiesAsync();

        Task<ExperienceDTO> GetEntityByIdAsync(int id);

        Task<ExperienceDTO> CreateEntityAsync(ExperienceRequest modelRequest);

        Task<IEnumerable<ExperienceDTO>> GetExperiencesByResumeId(int id);

        Task<bool> UpdateEntityByIdAsync(ExperienceRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
