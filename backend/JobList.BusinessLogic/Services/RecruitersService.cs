using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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

        public async Task<IEnumerable<RecruiterDTO>> GetRecruitersByCompanyId(int Id, PaginationUrlQuery urlQuery = null)
        {
            var entities = await _uow.RecruitersRepository.GetRangeAsync(filter: r => r.CompanyId == Id,
              include: r => r.Include(o => o.Company),
              paginationUrlQuery: urlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<RecruiterDTO>> GetFilteredRecruiters(int Id, string recruiterName = null, PaginationUrlQuery urlQuery = null)
        {
            List<Recruiter> entities;

            if (recruiterName != null)
            {
                entities = await _uow.RecruitersRepository.GetRangeAsync(filter: r => r.CompanyId == Id && r.FirstName.Contains(recruiterName),
                    include: r => r.Include(o => o.Company),
                    paginationUrlQuery: urlQuery);
            }
            else
            {
                entities = await _uow.RecruitersRepository.GetRangeAsync(filter: r => r.CompanyId == Id,
                include: r => r.Include(o => o.Company),
                paginationUrlQuery: urlQuery);
            }

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        public async Task<RecruiterDTO> CreateEntityAsync(RecruiterRequest modelRequest)
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

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.RecruitersRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<RecruiterDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.RecruitersRepository.GetAllEntitiesAsync(
                include: r => r.Include(o => o.Company));

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }


        public async Task<IEnumerable<RecruiterDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null)
        {
            var entities = await _uow.RecruitersRepository.GetAllEntitiesAsync(
                include: r => r.Include(o => o.Company));


            if (!string.IsNullOrEmpty(searchString))
            {
                entities = entities.Select(e => e)
                    .Where(d => d.Email.ToLower()
                    .Contains(searchString.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(sortingUrlQuery.SortField))
            {
                switch (sortingUrlQuery.SortField)
                {
                    case "Email":
                        if (sortingUrlQuery.SortOrder)
                            entities = entities.OrderBy(e => e.Email).ToList();
                        else
                            entities = entities.OrderByDescending(e => e.Email).ToList();
                        break;

                    default: break;
                }
            }

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        public async Task<RecruiterDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.RecruitersRepository.GetEntityAsync(id,
                include: r => r.Include(o => o.Company)
                                .Include(o => o.Vacancies).ThenInclude(v => v.WorkArea)
                                .Include(o => o.Vacancies).ThenInclude(v => v.City));

            if (entity == null) return null;

            var dto = _mapper.Map<Recruiter, RecruiterDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(RecruiterRequest modelRequest, int id)
        {
            var entity = _mapper.Map<RecruiterRequest, Recruiter>(modelRequest);
            entity.Id = id;

            var updated = await _uow.RecruitersRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }

        public Task<int> CountAsync(Expression<Func<Recruiter, bool>> predicate = null)
        {
            return _uow.RecruitersRepository.CountAsync(predicate);
        }
    }
}
