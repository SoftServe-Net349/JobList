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
    public class LanguagesService : ILanguagesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LanguagesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<LanguageDTO> CreateEntityAsync(LanguageRequest modelRequest)
        {
            var entity = _mapper.Map<LanguageRequest, Language>(modelRequest);

            entity = await _uow.LanguagesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Language, LanguageDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.LanguagesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<LanguageDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.LanguagesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Language>, List<LanguageDTO>>(entities);

            return dtos;
        }

        public async Task<LanguageDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.LanguagesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Language, LanguageDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(LanguageRequest modelRequest, int id)
        {
            var entity = _mapper.Map<LanguageRequest, Language>(modelRequest);
            entity.Id = id;

            var updated = await _uow.LanguagesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
