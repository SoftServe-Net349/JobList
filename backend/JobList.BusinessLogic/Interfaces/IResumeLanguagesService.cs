using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IResumeLanguagesService
    {
        Task<IEnumerable<ResumeLanguageDTO>> GetAllEntitiesAsync();

        Task<ResumeLanguageDTO> GetEntityByIdAsync(int id);

        Task<ResumeLanguageDTO> CreateEntityAsync(ResumeLanguageRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(ResumeLanguageRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
