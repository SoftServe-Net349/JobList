using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
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
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class VacanciesService : IVacanciesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public VacanciesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int TotalRecords
        {
            get { return _uow.VacanciesRepository.TotalRecords; }
        }

        public Task<int> CountAsync(Expression<Func<Vacancy, bool>> predicate = null)
        {
            return _uow.VacanciesRepository.CountAsync(predicate);
        }

        public async Task<VacancyDTO> CreateEntityAsync(VacancyRequest modelRequest)
        {
            var entity = _mapper.Map<VacancyRequest, Vacancy>(modelRequest);

            entity = await _uow.VacanciesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Vacancy, VacancyDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.VacanciesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<VacancyDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.VacanciesRepository.GetAllEntitiesAsync(
                 include: r => r.Include(o => o.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.Recruiter).ThenInclude(v => v.Company));


            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<VacancyDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery urlQuery = null)
        {
            var entities = await _uow.VacanciesRepository.GetRangeAsync(
                include: r => r.Include(o => o.City)
                    .Include(o => o.WorkArea)
                    .Include(o => o.Recruiter).ThenInclude(v => v.Company),
                paginationUrlQuery: urlQuery);

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(
            VacancyUrlQuery vacancyUrlQuery = null,
            SearchingUrlQuery searchingUrlQuery = null, 
            SortingUrlQuery sortingUrlQuery = null,
            PaginationUrlQuery paginationUrlQuery = null)
        {

            var filter = GetFilter(vacancyUrlQuery, searchingUrlQuery);

            var entities = await _uow.VacanciesRepository.GetRangeAsync(
                filter: filter,
                include: r => r.Include(o => o.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.Recruiter).ThenInclude(v => v.Company),
                sorting: GetSortField(sortingUrlQuery.SortField),
                sortOrder: sortingUrlQuery.SortOrder,
                paginationUrlQuery: paginationUrlQuery);

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);
            
            return dtos;
        }
        public async Task<IEnumerable<VacancyDTO>> GetVacanciesByRecruiterIdAsync(int recruiterId, PaginationUrlQuery urlQuery = null)
        {
            var entities = await _uow.VacanciesRepository.GetRangeAsync(filter: r => r.RecruiterId == recruiterId,
              include: r => r.Include(o => o.City)
                             .Include(o => o.WorkArea)
                             .Include(o => o.Recruiter).ThenInclude(v => v.Company),
              paginationUrlQuery: urlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(int? recruiterId,
                                                                           string searchString,
                                                                           PaginationUrlQuery paginationUrlQuery = null)
        {
            var filter = GetFilter(recruiterId, searchString);

            var entities = await _uow.VacanciesRepository.GetRangeAsync(
                 include: r => r.Include(o => o.City),
                 filter: filter,
                 paginationUrlQuery: paginationUrlQuery);

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }

        private Expression<Func<Vacancy, bool>> GetFilter(VacancyUrlQuery vacancyUrlQuery, SearchingUrlQuery searchingUrlQuery)
        {
            Expression<Func<Vacancy, bool>> filter = e => true;

            if (!string.IsNullOrEmpty(vacancyUrlQuery.Name))
            {
                filter = filter.And(е => е.Name
                    .Contains(vacancyUrlQuery.Name));
            }
            if (!string.IsNullOrEmpty(vacancyUrlQuery.City))
            {
                filter = filter.And(е => е.City.Name == vacancyUrlQuery.City);
            }
            if (!string.IsNullOrEmpty(vacancyUrlQuery.WorkArea))
            {
                filter = filter.And(е => е.WorkArea.Name == vacancyUrlQuery.WorkArea);
            }
            if (vacancyUrlQuery.NamesOfCompanies != null && !string.IsNullOrEmpty(vacancyUrlQuery.NamesOfCompanies[0]))
            {
                filter = filter.And(e => vacancyUrlQuery.NamesOfCompanies
                        .Contains(e.Recruiter.Company.Name));
            }
            if (vacancyUrlQuery.IsChecked.HasValue && vacancyUrlQuery.IsChecked.Value)
            {
                filter = filter.And(е => е.IsChecked == vacancyUrlQuery.IsChecked);
            }
            if (!string.IsNullOrEmpty(vacancyUrlQuery.TypeOfEmployment))
            {
                filter = filter.And(е => е.FullPartTime == vacancyUrlQuery.TypeOfEmployment);
            }
            if (vacancyUrlQuery.Salary.HasValue && vacancyUrlQuery.Salary.Value != 0)
            {
                filter = filter.And(е => е.Salary >= vacancyUrlQuery.Salary.Value);
            }

            if (!string.IsNullOrEmpty(searchingUrlQuery.SearchString))
            {
                filter = filter.And(e => e.Name
                    .Contains(searchingUrlQuery.SearchString));
            }

            return filter;
        }


        private Expression<Func<Vacancy, bool>> GetFilter(int? recruiterId, string searchString)
        {
            Expression<Func<Vacancy, bool>> filter = e => true;

            if (recruiterId != null)
            {
                filter = filter.And(r => (r.RecruiterId == recruiterId));
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                filter = filter.And(r => r.Name.Contains(searchString));
            }

            return filter;
        }


        private Expression<Func<Vacancy, string>> GetSortField(string field)
        {
            switch (field)
            {
                case "name":
                    return e => e.Name;
                case "createDate":
                    return e => e.CreateDate.ToString();

                default: return null;
            }
        }

        public async Task<VacancyDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.VacanciesRepository.GetEntityAsync(id,
                 include: r => r.Include(o => o.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.Recruiter).ThenInclude(v => v.Company));

            if (entity == null) return null;

            var dto = _mapper.Map<Vacancy, VacancyDTO>(entity);

            return dto;
        }

        public async Task<IEnumerable<VacancyDTO>> GetVacanciesByRectuiterId(int id)
        {
            var entities = await _uow.VacanciesRepository.GetRangeAsync(filter: r => r.RecruiterId == id,
                include: r => r.Include(v => v.Recruiter)
                                .Include(v => v.WorkArea)
                                .Include(v => v.City));

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);
            return dtos;
        }

        public async Task<bool> UpdateEntityByIdAsync(VacancyRequest modelRequest, int id)
        {
            var entity = _mapper.Map<VacancyRequest, Vacancy>(modelRequest);
            entity.Id = id;

            var updated = await _uow.VacanciesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
