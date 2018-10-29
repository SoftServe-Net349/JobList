using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobList.BusinessLogic.Services
{
    public class EducationPeriodsService : IEducationPeriodsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EducationPeriodsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<EducationPeriodDTO> CreateEntityAsync(EducationPeriodRequest modelRequest)
        {
            var entity = _mapper.Map<EducationPeriodRequest, EducationPeriod>(modelRequest);

            entity = await _uow.EducationPeriodsRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<EducationPeriod, EducationPeriodDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.EducationPeriodsRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<EducationPeriodDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.EducationPeriodsRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<EducationPeriod>, List<EducationPeriodDTO>>(entities);

            return dtos;
        }

        public async Task<EducationPeriodDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.EducationPeriodsRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<EducationPeriod, EducationPeriodDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(EducationPeriodRequest modelRequest, int id)
        {
            var entity = _mapper.Map<EducationPeriodRequest, EducationPeriod>(modelRequest);
            entity.Id = id;

            var updated = await _uow.EducationPeriodsRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
