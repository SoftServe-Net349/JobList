using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.Common.UrlQuery;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public async Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(VacancyUrlQuery vacancyUrlQuery = null)
        {
            var entities = await _uow.VacanciesRepository.GetAllEntitiesAsync(
                 include: r => r.Include(o => o.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.Recruiter).ThenInclude(v => v.Company));

            if (!string.IsNullOrEmpty(vacancyUrlQuery.Name))
            {
                entities = entities.Where(е => е.Name.ToLower()
                    .Contains(vacancyUrlQuery.Name.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(vacancyUrlQuery.City))
            {
                entities = entities.Where(е => е.City.Name == vacancyUrlQuery.City).ToList();
            }

            if (!string.IsNullOrEmpty(vacancyUrlQuery.WorkArea))
            {
                entities = entities.Where(е => е.WorkArea.Name == vacancyUrlQuery.WorkArea).ToList();
            }
            if (!(vacancyUrlQuery.NamesOfCompanies == null))
            {
                entities = (from x in entities
                           where vacancyUrlQuery.NamesOfCompanies.Contains(x.Recruiter.Company.Name)
                           select x).ToList();
            }
            if (!(vacancyUrlQuery.IsChecked == false))
            {
                entities = entities.Where(е => е.IsChecked == vacancyUrlQuery.IsChecked).ToList();
            }
            if (!string.IsNullOrEmpty(vacancyUrlQuery.TypeOfEmployment))
            {
                entities = entities.Where(е => е.FullPartTime == vacancyUrlQuery.TypeOfEmployment).ToList();
            }
            if (!(vacancyUrlQuery.Salary == 0))
            {
                entities = entities.Where(е => е.Salary >= vacancyUrlQuery.Salary).ToList();
            }

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }


        public async Task<IEnumerable<VacancyDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null)
        {
            List<Vacancy> entities = null;

            if (!string.IsNullOrEmpty(searchString))
            {
                entities = await _uow.VacanciesRepository.GetRangeAsync(
                    filter: e => e.Name.ToLower().Contains(searchString.ToLower()),
                    include: e => e.Include(o => o.City).Include(o => o.WorkArea).Include(o => o.Recruiter).ThenInclude(v => v.Company),
                    sorting: GetSortField(sortingUrlQuery.SortField),
                    sortOrder: sortingUrlQuery.SortOrder,
                    paginationUrlQuery: paginationUrlQuery);
            }
            else
            {
                entities = await _uow.VacanciesRepository.GetRangeAsync(
                    include: e => e.Include(o => o.City).Include(o => o.WorkArea).Include(o => o.Recruiter).ThenInclude(v => v.Company),
                    sorting: GetSortField(sortingUrlQuery.SortField),
                    sortOrder: sortingUrlQuery.SortOrder,
                    paginationUrlQuery: paginationUrlQuery);
            }

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }


        private Expression<Func<Vacancy, string>> GetSortField(string field)
        {
            switch (field)
            {
                case "Name":
                    return e => e.Name;
                case "CreateDate":
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
