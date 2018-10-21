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
    public interface IRecruitersService
    {
        Task<IEnumerable<RecruiterDTO>> GetAllRecruitersAsync();

        Task<RecruiterDTO> GetRecruiterByIdAsync(int id);

        Task<IEnumerable<RecruiterDTO>> GetRecruitersByCompanyIdAsync(int companyId, PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<RecruiterDTO>> GetFilteredRecruitersAsync(SearchingUrlQuery searchingUrlQuery = null, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null);


        Task<IEnumerable<RecruiterDTO>> GetFilteredRecruitersAsync(int? companyId = null,
                                                                   string searchString = null,
                                                                   SortingUrlQuery sortingUrlQuery = null,
                                                                   PaginationUrlQuery paginationUrlQuery = null);

        Task<RecruiterDTO> CreateRecruiterAsync(RecruiterRequest modelRequest);

        Task<bool> UpdateRecruiterByIdAsync(RecruiterUpdateRequest modelRequest, int id);

        Task<bool> DeleteRecruiterByIdAsync(int id);
        
        Task<int> CountAsync(Expression<Func<Recruiter, bool>> predicate = null);

        int TotalRecords { get; }
    }
}
