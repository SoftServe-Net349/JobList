using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ICompaniesService
    {
        Task<IEnumerable<CompanyDTO>> GetAllEntitiesAsync();

        Task<CompanyDTO> GetEntityByIdAsync(int id);

        Task<CompanyDTO> CreateEntityAsync(CompanyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(CompanyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
