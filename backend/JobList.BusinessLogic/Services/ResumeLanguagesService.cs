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
    public class ResumeLanguagesService : IResumeLanguagesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ResumeLanguagesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<ResumeLanguageDTO> CreateEntityAsync(ResumeLanguageRequest modelRequest)
        {
            var entity = _mapper.Map<ResumeLanguageRequest, ResumeLanguage>(modelRequest);

            entity = await _uow.ResumeLanguagesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<ResumeLanguage, ResumeLanguageDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.ResumeLanguagesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<ResumeLanguageDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.ResumeLanguagesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<ResumeLanguage>, List<ResumeLanguageDTO>>(entities);

            return dtos;
        }

        public async Task<ResumeLanguageDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.ResumeLanguagesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<ResumeLanguage, ResumeLanguageDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(ResumeLanguageRequest modelRequest, int id)
        {
            var entity = _mapper.Map<ResumeLanguageRequest, ResumeLanguage>(modelRequest);
            entity.Id = id;

            var updated = await _uow.ResumeLanguagesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
