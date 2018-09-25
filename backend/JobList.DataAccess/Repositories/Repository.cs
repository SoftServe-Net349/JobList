using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using JobList.Common.Errors;
using JobList.Common.Interfaces.Entities;
using JobList.DataAccess.Data;
using JobList.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobList.DataAccess.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly JobListDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected readonly IMapper _mapper;

        public Repository(JobListDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(TKey Id)
        {
            var entityToDelete = await _dbSet.FindAsync(Id);

            if (entityToDelete == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {Id} not found when trying to update entity. Entity was no Deleted.");
            }

            _dbSet.Remove(entityToDelete);
        }

        public async Task<List<TEntity>> GetAllEntitiesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetEntityAsync(TKey Id)
        {
            var entityToGet = await _dbSet.FindAsync(Id);

            if (entityToGet == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {Id} not found when trying to get entity.");
            }

            return entityToGet;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityToUpdate = await _dbSet.FindAsync(entity.Id);

            if (entityToUpdate == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {entity.Id} not found when trying to update entity. Entity is not updated");
            }

            return _mapper.Map(entity, entityToUpdate);
        }
    }
}
