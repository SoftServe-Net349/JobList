using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Extensions;
using JobList.Common.Pagination;
using JobList.Common.Requests;
using JobList.Common.UrlQuery;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public int TotalRecords
        {
            get { return _uow.ResumesRepository.TotalRecords; }
        }


        public Task<int> CountAsync(Expression<Func<Resume, bool>> predicate = null)
        {
            return _uow.ResumesRepository.CountAsync(predicate);
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
            var entities = await _uow.ResumesRepository.GetAllEntitiesAsync(
                 include: r => r.Include(o => o.Employee).ThenInclude(u => u.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.EducationPeriods).ThenInclude(e=>e.School)
                                .Include(o => o.EducationPeriods).ThenInclude(e => e.Faculty)
                                .Include(o => o.Experiences)
                                .Include(o => o.ResumeLanguages).ThenInclude(v => v.Language));

            var dtos = _mapper.Map<List<Resume>, List<ResumeDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<ResumeDTO>> GetRangeOfEntitiesAsync(PaginationUrlQuery urlQuery = null)
        {
            var entities = await _uow.ResumesRepository.GetRangeAsync(
                include: r => r.Include(o => o.Employee).ThenInclude(u => u.City)
                                .Include(o => o.WorkArea)
                                .Include(o => o.EducationPeriods).ThenInclude(e => e.School)
                                .Include(o => o.EducationPeriods).ThenInclude(e => e.Faculty)
                                .Include(o => o.Experiences)
                                .Include(o => o.ResumeLanguages).ThenInclude(v => v.Language),
                paginationUrlQuery: urlQuery);

            var dtos = _mapper.Map<List<Resume>, List<ResumeDTO>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<ResumeDTO>> GetFilteredEntitiesAsync(ResumeUrlQuery resumeUrlQuery = null, PaginationUrlQuery paginationUrlQuery = null)
        {
            var filter = GetFilter(resumeUrlQuery);

            var resumes = await _uow.ResumesRepository.GetRangeAsync(
                include: r => r.Include(o => o.Employee).ThenInclude(u => u.City)
                    .Include(o => o.WorkArea)
                    .Include(o => o.EducationPeriods).ThenInclude(e => e.School)
                    .Include(o => o.EducationPeriods).ThenInclude(e => e.Faculty)
                    .Include(o => o.Experiences)
                    .Include(o => o.ResumeLanguages).ThenInclude(v => v.Language),
                filter: filter,
                paginationUrlQuery: paginationUrlQuery);

            var dtos = _mapper.Map<List<Resume>, List<ResumeDTO>>(resumes);

            return dtos;
        }

        private Expression<Func<Resume, bool>> GetFilter(ResumeUrlQuery resumeUrlQuery)
        {
            Expression<Func<Resume, bool>> filter = e => true;

            if (!string.IsNullOrEmpty(resumeUrlQuery.Position))
            {
                filter = filter.And(r => r.Position
                    .Contains(resumeUrlQuery.Position));
            }

            if (!string.IsNullOrEmpty(resumeUrlQuery.WorkArea))
            {
                filter = filter.And(r => r.WorkArea.Name == resumeUrlQuery.WorkArea);
            }
            if (!string.IsNullOrEmpty(resumeUrlQuery.City))
            {
                filter = filter.And(r => r.Employee.City.Name == resumeUrlQuery.City);
            }
            if (resumeUrlQuery.StartAge.Value >= 0 && resumeUrlQuery.FinishAge.Value > 0)
            {
                filter = filter.And(r => (DateTime.Now - r.Employee.BirthDate).Days / 365 > resumeUrlQuery.StartAge &&
                                         (DateTime.Now - r.Employee.BirthDate).Days / 365 < resumeUrlQuery.FinishAge);
            }
            if (resumeUrlQuery.Languages != null)
            {
                filter = filter.And(r => r.ResumeLanguages
                    .Any(rl => resumeUrlQuery.Languages.Contains(rl.Language.Name)));
            }
            if (resumeUrlQuery.Schools != null)
            {
                filter = filter.And(r => r.EducationPeriods
                    .Any(ep => resumeUrlQuery.Schools.Contains(ep.School.Name)));
            }
            if (resumeUrlQuery.Faculties != null)
            {
                filter = filter.And(r => r.EducationPeriods
                    .Any(ep => resumeUrlQuery.Faculties.Contains(ep.Faculty.Name)));
            }

            return filter;
        }


        public async Task<ResumeDTO> GetEntityByIdAsync(int id)
        {
            var entity = await _uow.ResumesRepository.GetEntityAsync(id,
                 include: r => r.Include(o => o.Employee).ThenInclude(u => u.City)
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
