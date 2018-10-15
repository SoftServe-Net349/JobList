using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IRecruitersService
    {
        Task<IEnumerable<RecruiterDTO>> GetRecruitersByCompanyId(int Id, PaginationUrlQuery urlQuery = null);

        Task<IEnumerable<RecruiterDTO>> GetAllEntitiesAsync();

        Task<RecruiterDTO> GetEntityByIdAsync(int id);

        Task<RecruiterDTO> CreateEntityAsync(RecruiterRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(RecruiterRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);

        Task<IEnumerable<RecruiterDTO>> GetFilteredRecruiters(int Id, string recruiterName = null, PaginationUrlQuery urlQuery = null);

        Task<int> CountAsync(Expression<Func<Recruiter, bool>> predicate = null);
    }
}
