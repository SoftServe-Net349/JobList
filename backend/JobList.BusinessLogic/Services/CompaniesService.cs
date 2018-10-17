using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Errors;
using JobList.Common.Requests;
using JobList.Common.Sorting;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<CompanyDTO>> GetFilteredEntitiesAsync(string searchString, SortingUrlQuery sortingUrlQuery = null)
        {
            var entities = await _uow.CompaniesRepository.GetAllEntitiesAsync();


            if (!string.IsNullOrEmpty(searchString))
            {
                entities = entities.Select(e => e)
                    .Where(d => d.Name.ToLower()
                    .Contains(searchString.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(sortingUrlQuery.SortField))
            {
                switch (sortingUrlQuery.SortField)
                {
                    case "Name":
                        if (sortingUrlQuery.SortOrder)
                            entities = entities.OrderBy(e => e.Name).ToList();
                        else
                            entities = entities.OrderByDescending(e => e.Name).ToList();
                        break;

                    default: break;
                }
            }

            var dtos = _mapper.Map<List<Company>, List<CompanyDTO>>(entities);

            return dtos;
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
