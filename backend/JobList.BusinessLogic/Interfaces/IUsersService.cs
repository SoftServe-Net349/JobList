using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<UserDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<UserDTO> GetEntityByIdAsync(int id);

        Task<UserDTO> CreateEntityAsync(UserRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(UserRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<User, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
