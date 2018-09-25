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
    public class WorkAreasService : IWorkAreasService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public WorkAreasService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<WorkAreaDTO> CreateEntityAsync(WorkAreaRequest modelRequest)
        {
            var entity = _mapper.Map<WorkAreaRequest, WorkArea>(modelRequest);

            entity = await _uow.WorkAreasRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<WorkArea, WorkAreaDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.WorkAreasRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<WorkAreaDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.WorkAreasRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<WorkArea>, List<WorkAreaDTO>>(entities);

            return dtos;
        }

        public async Task<WorkAreaDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.WorkAreasRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<WorkArea, WorkAreaDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(WorkAreaRequest modelRequest, int id)
        {
            var entity = _mapper.Map<WorkAreaRequest, WorkArea>(modelRequest);
            entity.Id = id;

            var updated = await _uow.WorkAreasRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
