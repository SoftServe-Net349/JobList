using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class VacanciesService : IVacanciesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public int Count
        {
            get { return _uow.VacanciesRepository.Count; }
        }

        public VacanciesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<VacancyDTO> CreateEntityAsync(VacancyRequest modelRequest)
        {
            var entity = _mapper.Map<VacancyRequest, Vacancy>(modelRequest);

            entity = await _uow.VacanciesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Vacancy, VacancyDTO>(entity);

            return dto;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.VacanciesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<VacancyDTO>> GetAllEntitiesAsync(UrlQuery urlQuery)
        {
            var entities = await _uow.VacanciesRepository.GetAllEntitiesAsync(
                 include: r => r.Include(o => o.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.Recruiter).ThenInclude(v => v.Company));

            if(urlQuery != null)
            {
                entities = entities
                    .Skip(urlQuery.PageCount * (urlQuery.PageNumber - 1))
                    .Take(urlQuery.PageCount)
                    .ToList();
            }


            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);

            return dtos;
        }

        public async Task<VacancyDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.VacanciesRepository.GetEntityAsync(id,
                 include: r => r.Include(o => o.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.Recruiter).ThenInclude(v => v.Company));

            if (entity == null) return null;

            var dto = _mapper.Map<Vacancy, VacancyDTO>(entity);

            return dto;
        }

        public async Task<IEnumerable<VacancyDTO>> GetVacanciesByRectuiterId(int id)
        {
            var entities = await _uow.VacanciesRepository.GetRangeAsync(filter: r => r.RecruiterId == id,
                include: r => r.Include(v=> v.Recruiter)
                                .Include(v => v.City));

            if (entities == null) return null;

            var dtos = _mapper.Map<List<Vacancy>, List<VacancyDTO>>(entities);
            return dtos;
        }

        public async Task<bool> UpdateEntityByIdAsync(VacancyRequest modelRequest, int id)
        {
            var entity = _mapper.Map<VacancyRequest, Vacancy>(modelRequest);
            entity.Id = id;

            var updated = await _uow.VacanciesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
