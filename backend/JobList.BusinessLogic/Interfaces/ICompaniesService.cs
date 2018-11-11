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
    public interface ICompaniesService
    {
        Task<IEnumerable<CompanyDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<CompanyDTO>> GetFilteredEntitiesAsync(SearchingUrlQuery searchingUrlQuery = null, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<CompanyDTO> GetEntityByIdAsync(int id);

        Task<CompanyDTO> CreateEntityAsync(CompanyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(CompanyUpdateRequest modelRequest, int id);

        Task<bool> ResetEntityByIdAsync(CompanyResetPasswordRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<Company, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
