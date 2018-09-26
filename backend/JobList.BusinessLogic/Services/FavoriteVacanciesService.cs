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
    public class FavoriteVacanciesService : IFavoriteVacanciesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FavoriteVacanciesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<FavoriteVacancyDTO> CreateEntityAsync(FavoriteVacancyRequest modelRequest)
        {
            var entity = _mapper.Map<FavoriteVacancyRequest, FavoriteVacancy>(modelRequest);

            entity = await _uow.FavoriteVacanciesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<FavoriteVacancy, FavoriteVacancyDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.FavoriteVacanciesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<FavoriteVacancyDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.FavoriteVacanciesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<FavoriteVacancy>, List<FavoriteVacancyDTO>>(entities);

            return dtos;
        }

        public async Task<FavoriteVacancyDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.FavoriteVacanciesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<FavoriteVacancy, FavoriteVacancyDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(FavoriteVacancyRequest modelRequest, int id)
        {
            var entity = _mapper.Map<FavoriteVacancyRequest, FavoriteVacancy>(modelRequest);
            entity.Id = id;

            var updated = await _uow.FavoriteVacanciesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
