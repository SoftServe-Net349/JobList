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
    public class ResumesService : IResumesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ResumesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<ResumeDTO> CreateEntityAsync(ResumeRequest modelRequest)
        {
            var entity = _mapper.Map<ResumeRequest, Resume>(modelRequest);

            entity = await _uow.ResumesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Resume, ResumeDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.ResumesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<ResumeDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.ResumesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Resume>, List<ResumeDTO>>(entities);

            return dtos;
        }

        public async Task<ResumeDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.ResumesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Resume, ResumeDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(ResumeRequest modelRequest, int id)
        {
            var entity = _mapper.Map<ResumeRequest, Resume>(modelRequest);
            entity.Id = id;

            var updated = await _uow.ResumesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
