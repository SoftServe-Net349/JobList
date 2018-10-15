using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.UrlQuery;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobList.Common.Sorting;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IVacanciesService
    {
        Task<IEnumerable<VacancyDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<VacancyDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(VacancyUrlQuery vacancyUrlQuery = null);

        Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null);


        Task<VacancyDTO> GetEntityByIdAsync(int id);

        Task<VacancyDTO> CreateEntityAsync(VacancyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(VacancyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<IEnumerable<VacancyDTO>> GetVacanciesByRectuiterId(int id);

        int Count { get; }
    }
}
