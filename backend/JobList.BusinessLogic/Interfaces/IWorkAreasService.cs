using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IWorkAreasService
    {
        Task<IEnumerable<WorkAreaDTO>> GetAllEntitiesAsync();

        Task<WorkAreaDTO> GetEntityByIdAsync(int id);

        Task<WorkAreaDTO> CreateEntityAsync(WorkAreaRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(WorkAreaRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
