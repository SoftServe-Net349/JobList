using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.UrlQuery;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobList.Common.Sorting;
using JobList.DataAccess.Entities;
using System;
using System.Linq.Expressions;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IVacanciesService
    {
        Task<IEnumerable<VacancyDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<VacancyDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(VacancyUrlQuery vacancyUrlQuery = null, SearchingUrlQuery searchingUrlQuery = null, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<VacancyDTO> GetEntityByIdAsync(int id);

        Task<VacancyDTO> CreateEntityAsync(VacancyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(VacancyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<IEnumerable<VacancyDTO>> GetVacanciesByRectuiterId(int id);

        Task<int> CountAsync(Expression<Func<Vacancy, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
