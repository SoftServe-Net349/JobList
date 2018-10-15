using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ICompaniesService
    {
        Task<IEnumerable<CompanyDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<CompanyDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null);

        Task<CompanyDTO> GetEntityByIdAsync(int id);

        Task<CompanyDTO> CreateEntityAsync(CompanyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(CompanyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
