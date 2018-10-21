using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Extensions;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.Common.UrlQuery;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class RecruitersService : IRecruitersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RecruitersService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int TotalRecords
        {
            get { return _uow.RecruitersRepository.TotalRecords; }
        }

        public async Task<IEnumerable<RecruiterDTO>> GetAllRecruitersAsync()
        {
            var entities = await _uow.RecruitersRepository.GetAllEntitiesAsync(
                include: r => r.Include(o => o.Company)
                               .Include(o => o.Role));

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        public async Task<RecruiterDTO> GetRecruiterByIdAsync(int id)
        {
            var entity = await _uow.RecruitersRepository.GetEntityAsync(id,
                include: r => r.Include(o => o.Company)
                               .Include(o => o.Role));

            if (entity == null) return null;

            var dto = _mapper.Map<Recruiter, RecruiterDTO>(entity);

            return dto;
        }

        public async Task<IEnumerable<RecruiterDTO>> GetRecruitersByCompanyIdAsync(int companyId, PaginationUrlQuery urlQuery = null)
        {
            var entities = await _uow.RecruitersRepository.GetRangeAsync(filter: r => r.CompanyId == companyId,
              include: r => r.Include(o => o.Company)
                             .Include(o => o.Role),
              paginationUrlQuery: urlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<RecruiterDTO>> GetFilteredRecruitersAsync(int? companyId,
                                                                                string searchString = null,
                                                                                SortingUrlQuery sortingUrlQuery = null,
                                                                                PaginationUrlQuery paginationUrlQuery = null)
        {

            Expression<Func<Recruiter, bool>> filter = e => true;

            string[] searchList;

            if (companyId != null)
            {
                filter = filter.And(r => (r.CompanyId == companyId));
            }

            if (!String.IsNullOrEmpty(searchString) && IsEmailValid(searchString))
            {
                filter = filter.And(r => r.Email.Contains(searchString));
            }

            else if (!String.IsNullOrEmpty(searchString) && !IsEmailValid(searchString))
            {
                searchList = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (searchList.Length > 1)
                {
                    filter = filter.And(r => (r.FirstName.Contains(searchList[0]) && r.LastName.Contains(searchList[1])) ||
                                            (r.FirstName.Contains(searchList[1]) && r.LastName.Contains(searchList[0])));
                }
                else
                {
                    filter = filter.And(r => r.FirstName.Contains(searchList[0]) ||
                                        r.LastName.Contains(searchList[0]));
                }
            }

            var entities = await _uow.RecruitersRepository.GetRangeAsync(
                 filter: filter,
                 include: r => r.Include(o => o.Company),
                 sorting: GetSortField(sortingUrlQuery?.SortField),
                 sortOrder: sortingUrlQuery?.SortOrder,
                 paginationUrlQuery: paginationUrlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }


        public async Task<IEnumerable<RecruiterDTO>> GetFilteredRecruitersAsync(SearchingUrlQuery searchingUrlQuery, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null)
        {
            Expression<Func<Recruiter, bool>> filter = e => true;

            if (!string.IsNullOrEmpty(searchingUrlQuery.SearchString))
            {
                filter = filter.And(GetSearchField(searchingUrlQuery));
            }

            var entities = await _uow.RecruitersRepository.GetRangeAsync(
                filter: filter,
                include: e => e.Include(o => o.Company),
                sorting: GetSortField(sortingUrlQuery.SortField),
                sortOrder: sortingUrlQuery.SortOrder,
                paginationUrlQuery: paginationUrlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        private Expression<Func<Recruiter, string>> GetSortField(string field)
        {
            switch (field)
            {
                case "firstName":
                    return r => r.FirstName;
                case "lastName":
                    return r => r.LastName;
                case "email":
                    return r => r.Email;
            }
            return null;
        }

        private Expression<Func<Recruiter, bool>> GetSearchField(SearchingUrlQuery searchingUrlQuery)
        {
            switch (searchingUrlQuery.SearchField)
            {
                case "firstName":
                    return e => e.FirstName.Contains(searchingUrlQuery.SearchString);
                case "lastName":
                    return e => e.LastName.Contains(searchingUrlQuery.SearchString);
                case "email":
                    return e => e.Email.Contains(searchingUrlQuery.SearchString);

                default: return null;
            }
        }



        public async Task<RecruiterDTO> CreateRecruiterAsync(RecruiterRequest modelRequest)
        {
            if (await _uow.RecruitersRepository.ExistAsync(u => u.Email == modelRequest.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "This email already exists!");
            }

            var entity = _mapper.Map<RecruiterRequest, Recruiter>(modelRequest);

            entity = await _uow.RecruitersRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Recruiter, RecruiterDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteRecruiterByIdAsync(int id)
        {
            await _uow.RecruitersRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<bool> UpdateRecruiterByIdAsync(RecruiterUpdateRequest modelRequest, int id)
        {
            var entity = _mapper.Map<RecruiterUpdateRequest, Recruiter>(modelRequest);
            entity.Id = id;

            var updated = await _uow.RecruitersRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }

        public Task<int> CountAsync(Expression<Func<Recruiter, bool>> predicate = null)
        {
            return _uow.RecruitersRepository.CountAsync(predicate);
        }

        private bool IsEmailValid(string value)
        {
            try
            {
                MailAddress m = new MailAddress(value);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
