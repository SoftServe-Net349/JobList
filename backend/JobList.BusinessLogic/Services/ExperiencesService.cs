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
    public class ExperiencesService : IExperiencesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ExperiencesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<ExperienceDTO> CreateEntityAsync(ExperienceRequest modelRequest)
        {
            var entity = _mapper.Map<ExperienceRequest, Experience>(modelRequest);

            entity = await _uow.ExperiencesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Experience, ExperienceDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.ExperiencesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<ExperienceDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.ExperiencesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Experience>, List<ExperienceDTO>>(entities);

            return dtos;
        }

        public async Task<ExperienceDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.ExperiencesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Experience, ExperienceDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(ExperienceRequest modelRequest, int id)
        {
            var entity = _mapper.Map<ExperienceRequest, Experience>(modelRequest);
            entity.Id = id;

            var entityUpdate = await _uow.ExperiencesRepository.GetFirstOrDefaultAsync(filter: u => u.Id == id);

            if (entityUpdate != null)
            {
                var updated = await _uow.ExperiencesRepository.UpdateAsync(entity);
            }
            else
            {
                var created = await _uow.ExperiencesRepository.CreateEntityAsync(entity);
            }

            var result = await _uow.SaveAsync();

            return result;

        }
    }
}
