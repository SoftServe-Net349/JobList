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
    public class RolesService : IRolesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RolesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<RoleDTO> CreateEntityAsync(RoleRequest modelRequest)
        {
            var entity = _mapper.Map<RoleRequest, Role>(modelRequest);

            entity = await _uow.RolesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Role, RoleDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.RolesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.RolesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Role>, List<RoleDTO>>(entities);

            return dtos;
        }

        public async Task<RoleDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.RolesRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Role, RoleDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(RoleRequest modelRequest, int id)
        {
            var entity = _mapper.Map<RoleRequest, Role>(modelRequest);
            entity.Id = id;

            var updated = await _uow.RolesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
