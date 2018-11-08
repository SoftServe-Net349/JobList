using AutoMapper;
using JobList.BusinessLogic.Hubs;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class InvitationsService : IInvitationsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IHubContext<InvitationHub> _hubContext;
        IEmailSender _emailProvider;

        public InvitationsService(IUnitOfWork uow, IMapper mapper, IHubContext<InvitationHub> hubContext, IEmailSender emailProvider)
        {
            _uow = uow;
            _mapper = mapper;
            _hubContext = hubContext;
            _emailProvider = emailProvider;
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
            entity.Vacancy = await _uow.VacanciesRepository.GetEntityAsync(request.VacancyId,
                                                                           include: r => r.Include(o => o.City)
                                                                            .Include(o => o.WorkArea)
                                                                            .Include(o => o.Recruiter).ThenInclude(v => v.Company));

            var employee = await _uow.EmployeesRepository.GetEntityAsync(int.Parse(request.EmployeeId));

            var dto = _mapper.Map<Invitation, InvitationDTO>(entity);

            await this._emailProvider.SendEmailAsync(employee.Email, "Invitation", entity.Vacancy.Name);

            await _hubContext.Clients.User(request.EmployeeId).SendAsync("receiveInvitation", dto);

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
            var entities = await _uow.InvitationsRepository.GetAllEntitiesAsync(
                                            include: r=> r.Include(i => i.Vacancy).ThenInclude(v => v.City)
                                            .Include(i => i.Vacancy).ThenInclude(v => v.WorkArea)
                                            .Include(i => i.Vacancy).ThenInclude(v => v.Recruiter).ThenInclude(rec => rec.Company));

            var dtos = _mapper.Map<List<Invitation>, List<InvitationDTO>>(entities);

            return dtos;
        }

        public async Task<InvitationDTO> GetInvitationByIdAsync(int id)
        {
            var entity = await _uow.InvitationsRepository.GetEntityAsync(id,
                                            include: r => r.Include(i => i.Vacancy).ThenInclude(v => v.City)
                                            .Include(i => i.Vacancy).ThenInclude(v => v.WorkArea)
                                            .Include(i => i.Vacancy).ThenInclude(v => v.Recruiter).ThenInclude(rec => rec.Company));

            if (entity == null) return null;

            var dto = _mapper.Map<Invitation, InvitationDTO>(entity);

            return dto;
        }

        public async Task<IEnumerable<InvitationDTO>> GetInvitationsByEmployeeIdAsync(int employeeId, PaginationUrlQuery urlQuery = null)
        {
            var entities = await _uow.InvitationsRepository.GetRangeAsync(filter: i => i.EmployeeId == employeeId,
                                            include: r => r.Include(i => i.Vacancy).ThenInclude(v => v.City)
                                            .Include(i => i.Vacancy).ThenInclude(v => v.WorkArea)
                                            .Include(i => i.Vacancy).ThenInclude(v => v.Recruiter).ThenInclude(rec => rec.Company),
                                            paginationUrlQuery: urlQuery);

            var dtos = _mapper.Map<List<Invitation>, List<InvitationDTO>>(entities);

            return dtos;
        }

        public async Task<bool> UpdateInvitationByIdAsync(InvitationRequest request, int id)
        {
            var entity = _mapper.Map<InvitationRequest, Invitation>(request);
            entity.Id = id;

            var updated = await _uow.InvitationsRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }

        public Task<int> CountAsync(Expression<Func<Invitation, bool>> predicate = null)
        {
            return _uow.InvitationsRepository.CountAsync(predicate);
        }

    }
}
