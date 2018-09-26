using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using System.Collections.Generic;
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
            var entities = await _uow.VacanciesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }

        public async Task<VacancyDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.VacanciesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Vacancy, VacancyDTO>(entity);

            return dto;
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
