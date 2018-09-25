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
    public class FacultiesService : IFacultiesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FacultiesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<FacultyDTO> CreateEntityAsync(FacultyRequest modelRequest)
        {
            var entity = _mapper.Map<FacultyRequest, Faculty>(modelRequest);

            entity = await _uow.FacultiesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Faculty, FacultyDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.FacultiesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<FacultyDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.FacultiesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Faculty>, List<FacultyDTO>>(entities);

            return dtos;
        }

        public async Task<FacultyDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.FacultiesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Faculty, FacultyDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(FacultyRequest modelRequest, int id)
        {
            var entity = _mapper.Map<FacultyRequest, Faculty>(modelRequest);
            entity.Id = id;

            var updated = await _uow.FacultiesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
