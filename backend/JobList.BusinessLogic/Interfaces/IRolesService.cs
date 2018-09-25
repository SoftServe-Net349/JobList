using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<RoleDTO>> GetAllEntitiesAsync();

        Task<RoleDTO> GetEntityByIdAsync(int id);

        Task<RoleDTO> CreateEntityAsync(RoleRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(RoleRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
