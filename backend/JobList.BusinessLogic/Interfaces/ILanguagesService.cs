using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ILanguagesService
    {
        Task<IEnumerable<LanguageDTO>> GetAllEntitiesAsync();

        Task<LanguageDTO> GetEntityByIdAsync(int id);

        Task<LanguageDTO> CreateEntityAsync(LanguageRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(LanguageRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
