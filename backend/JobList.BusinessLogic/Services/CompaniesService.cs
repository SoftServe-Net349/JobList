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
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class CompaniesService : ICompaniesService
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CompaniesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int TotalRecords
        {
            get { return _uow.CompaniesRepository.TotalRecords; }
        }

        public Task<int> CountAsync(Expression<Func<Company, bool>> predicate = null)
        {
            return _uow.CompaniesRepository.CountAsync(predicate);
        }


        public async Task<CompanyDTO> CreateEntityAsync(CompanyRequest modelRequest)
        {
            if (await _uow.CompaniesRepository.ExistAsync(u => u.Email == modelRequest.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "This email already exists!");
            }

            var entity = _mapper.Map<CompanyRequest, Company>(modelRequest);

            entity = await _uow.CompaniesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Company, CompanyDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.CompaniesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.CompaniesRepository.GetAllEntitiesAsync();

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Company>, List<CompanyDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<CompanyDTO>> GetFilteredEntitiesAsync(SearchingUrlQuery searchingUrlQuery = null, SortingUrlQuery sortingUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null)
        {
            Expression<Func<Company, bool>> filter = e => true;

            if (!string.IsNullOrEmpty(searchingUrlQuery.SearchString))
            {
                filter = filter.And(GetSearchField(searchingUrlQuery));
            }

            var entities = await _uow.CompaniesRepository.GetRangeAsync(
                filter: filter,
                sorting: GetSortField(sortingUrlQuery.SortField),
                sortOrder: sortingUrlQuery.SortOrder,
                paginationUrlQuery: paginationUrlQuery);


            var dtos = _mapper.Map<List<Company>, List<CompanyDTO>>(entities);

            return dtos;
        }


        private Expression<Func<Company, string>> GetSortField(string field)
        {
            switch (field)
            {
                case "name":
                    return e => e.Name;
                case "email":
                    return e => e.Email;
            }

            return null;
        }

        private Expression<Func<Company, bool>> GetSearchField(SearchingUrlQuery searchingUrlQuery)
        {
            switch (searchingUrlQuery.SearchField)
            {
                case "name":
                    return e => e.Name.Contains(searchingUrlQuery.SearchString);
                case "email":
                    return e => e.Email.Contains(searchingUrlQuery.SearchString);

                default: return null;
            }
        }


        public async Task<CompanyDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.CompaniesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Company, CompanyDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(CompanyRequest modelRequest, int id)
        {
            var entity = _mapper.Map<CompanyRequest, Company>(modelRequest);
            entity.Id = id;

            var updated = await _uow.CompaniesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
