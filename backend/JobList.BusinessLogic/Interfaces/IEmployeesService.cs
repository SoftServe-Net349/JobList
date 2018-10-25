using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.Common.UrlQuery;
using JobList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<EmployeeDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery paginationUrlQuery = null);

        Task<IEnumerable<EmployeeDTO>> GetFilteredEntitiesAsync(SearchingUrlQuery searchingUrlQuery, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<EmployeeDTO> GetEntityByIdAsync(int id);

        Task<EmployeeDTO> CreateEntityAsync(EmployeeRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(EmployeeUpdateRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<Employee, bool>> predicate = null);

        Task<bool> ExistAsync(Expression<Func<Employee, bool>> predicate);

        int TotalRecords { get; }
    }
}
