using JobList.Common.DTOS;
using JobList.Common.Requests;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAllEntitiesAsync();

        Task<UserDTO> GetEntityByIdAsync(int id);

        Task<UserDTO> GetAuthenticatedUserAsync(string email, string password);

        Task<UserDTO> CreateEntityAsync(UserRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(UserRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
