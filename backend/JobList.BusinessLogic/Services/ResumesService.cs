using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public int Count { get { return _uow.ResumesRepository.Count; } }


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

        public async Task<IEnumerable<ResumeDTO>> GetAllEntitiesAsync(UrlQuery urlQuery = null)
        {
            var entities = await _uow.ResumesRepository.GetAllEntitiesAsync(
                 include: r => r.Include(o => o.User).ThenInclude(u => u.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.EducationPeriods).ThenInclude(e=>e.School)
                                .Include(o => o.EducationPeriods).ThenInclude(e => e.Faculty)
                                .Include(o => o.Experiences)
                                .Include(o => o.ResumeLanguages).ThenInclude(v => v.Language),
                 urlQuery: urlQuery);

            var dtos = _mapper.Map<List<Resume>, List<ResumeDTO>>(entities);

            return dtos;
        }

        public async Task<ResumeDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.ResumesRepository.GetEntityAsync(id,
                 include: r => r.Include(o => o.User).ThenInclude(u => u.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.EducationPeriods).ThenInclude(e => e.School)
                                .Include(o => o.EducationPeriods).ThenInclude(e => e.Faculty)
                                .Include(o => o.Experiences)
                                .Include(o => o.ResumeLanguages).ThenInclude(v => v.Language));

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
