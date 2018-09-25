using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAllEntitiesAsync();

        Task<UserDTO> GetEntityByIdAsync(int id);

        Task<UserDTO> CreateEntityAsync(UserRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(UserRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
