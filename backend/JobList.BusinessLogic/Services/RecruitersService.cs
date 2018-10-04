using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class RecruitersService : IRecruitersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RecruitersService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecruiterDTO>> GetRecruitersByCompanyId(int Id)
        {
            var entities = await _uow.RecruitersRepository.GetRangeAsync(filter: r=> r.CompanyId ==Id,
                include: r => r.Include(o => o.Company));

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        public async Task<RecruiterDTO> CreateEntityAsync(RecruiterRequest modelRequest)
        {
            var entity = _mapper.Map<RecruiterRequest, Recruiter>(modelRequest);

            entity = await _uow.RecruitersRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Recruiter, RecruiterDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.RecruitersRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<RecruiterDTO>> GetAllEntitiesAsync()
        {
            var entities = await _uow.RecruitersRepository.GetAllEntitiesAsync(
                include: r => r.Include(o => o.Company));

            var dtos = _mapper.Map<List<Recruiter>, List<RecruiterDTO>>(entities);

            return dtos;
        }

        public async Task<RecruiterDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.RecruitersRepository.GetEntityAsync(id,
                include: r => r.Include(o => o.Company)
                                .Include(o => o.Vacancies).ThenInclude(v => v.WorkArea)
                                .Include(o => o.Vacancies).ThenInclude(v => v.City));

            if (entity == null) return null;

            var dto = _mapper.Map<Recruiter, RecruiterDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(RecruiterRequest modelRequest, int id)
        {
            var entity = _mapper.Map<RecruiterRequest, Recruiter>(modelRequest);
            entity.Id = id;

            var updated = await _uow.RecruitersRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
