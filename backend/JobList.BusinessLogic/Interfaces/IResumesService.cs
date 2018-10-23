using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.UrlQuery;
using JobList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IResumesService
    {
        Task<IEnumerable<ResumeDTO>> GetAllEntitiesAsync();

        Task<IEnumerable<ResumeDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<ResumeDTO>> GetFilteredEntitiesAsync(ResumeUrlQuery resumeUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);

        Task<ResumeDTO> GetEntityByIdAsync(int id);

        Task<ResumeDTO> CreateEntityAsync(ResumeRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(ResumeRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<int> CountAsync(Expression<Func<Resume, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
