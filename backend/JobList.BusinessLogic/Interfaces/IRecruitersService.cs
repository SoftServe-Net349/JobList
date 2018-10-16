using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IRecruitersService
    {
        Task<IEnumerable<RecruiterDTO>> GetRecruitersByCompanyId(int Id);

        Task<IEnumerable<RecruiterDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<RecruiterDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<RecruiterDTO> GetEntityByIdAsync(int id);

        Task<RecruiterDTO> CreateEntityAsync(RecruiterRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(RecruiterRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        int TotalRecords { get; }
    }
}
