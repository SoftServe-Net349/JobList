using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using Microsoft.EntityFrameworkCore.Query;
using System;
using JobList.Common.Sorting;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<UserDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery paginationUrlQuery = null);

        Task<IEnumerable<UserDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null);

        Task<UserDTO> GetEntityByIdAsync(int id);

        Task<UserDTO> CreateEntityAsync(UserRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(UserRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        int Count { get; }
    }
}
