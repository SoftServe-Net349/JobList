﻿using AutoMapper;
using JobList.BusinessLogic.Interfaces;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Services
{
    public class SamplesService : ISamplesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SamplesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SampleDTO>> GetAllEntitiesAsync()
        {
            var samples = await _uow.SamplesRepository.GetAllEntitiesAsync();

            var dtos = _mapper.Map<List<Sample>, List<SampleDTO>>(samples);

            return dtos;
        }

        public async Task<SampleDTO> GetEntityByIdAsync(int id)
        {
            var sample = await _uow.SamplesRepository.GetEntityAsync(id);

            if (sample == null) return null;

            var dto = _mapper.Map<Sample, SampleDTO>(sample);

            return dto;
        }

        public async Task<SampleDTO> CreateEntityAsync(SampleRequest request)
        {
            var entity = _mapper.Map<SampleRequest, Sample>(request);

            entity = await _uow.SamplesRepository.CreateEntityAsync(entity);
            var result = await _uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            if (entity == null) return null;

            var dto = _mapper.Map<Sample, SampleDTO>(entity);

            return dto;
        }

        public async Task<bool> UpdateEntityByIdAsync(SampleRequest request, int id)
        {
            var entity = _mapper.Map<SampleRequest, Sample>(request);
            entity.Id = id;

            // In returns updated entity, you could do smth with it or just leave as it is
            var updated = await _uow.SamplesRepository.UpdateAsync(entity);
            var result = await _uow.SaveAsync();

            return result;
        }

        public async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await _uow.SamplesRepository.DeleteAsync(id);

            var result = await _uow.SaveAsync();

            return result;
        }
    }
}
