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
    public class InvitationsService : IInvitationsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public InvitationsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<InvitationDTO> CreateInvitationAsync(InvitationRequest request)
        {
            var entity = _mapper.Map<InvitationRequest, Invitation>(request);

            entity = await _uow.InvitationsRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Invitation, InvitationDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteInvitationByIdAsync(int id)
        {
            await _uow.InvitationsRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<InvitationDTO>> GetAllInvitationsAsync()
        {
            var entities = await _uow.InvitationsRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Invitation>, List<InvitationDTO>>(entities);

            return dtos;
        }

        public async Task<InvitationDTO> GetInvitationByIdAsync(int id)
        {
            var entity = await _uow.InvitationsRepository.GetEntityAsync(id);

            if (entity == null) return null;

            var dto = _mapper.Map<Invitation, InvitationDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateInvitationByIdAsync(InvitationRequest request, int id)
        {
            var entity = _mapper.Map<InvitationRequest, Invitation>(request);
            entity.Id = id;

            var updated = await _uow.InvitationsRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
