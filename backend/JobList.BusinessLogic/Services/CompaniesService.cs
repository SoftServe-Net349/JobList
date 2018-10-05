using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
