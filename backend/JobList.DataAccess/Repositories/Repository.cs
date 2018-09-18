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
using Microsoft.EntityFrameworkCore.Query;

namespace JobList.DataAccess.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly JobListDbContext context;
        protected readonly DbSet<TEntity> Dbset;

        protected readonly IMapper mapper;

        public Repository(JobListDbContext _context, IMapper automapper)
        {
            context = _context;
            mapper = automapper;
            Dbset = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateEntityAsync(TEntity entity)
        {
            await Dbset.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(TKey Id)
        {
            var entityToDelite = await Dbset.FindAsync(Id);

            if (entityToDelite == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {Id} not found when trying to update entity. Entity was no Deleted.");
            }

             Dbset.Remove(entityToDelite);
        }

        public async Task<List<TEntity>> GetAllEntitiesAsync()
        {
            return await Dbset.ToListAsync();
        }

        public async Task<TEntity> GetEntityAsync(TKey Id)
        {
            var entityToGet = await Dbset.FindAsync(Id);

            if (entityToGet == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {Id} not found when trying to get entity.");
            }

            return entityToGet;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityToUpdate = await Dbset.FindAsync(entity.Id);

            if (entityToUpdate == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {entity.Id} not found when trying to update entity. Entity is not updated");
            }

            return mapper.Map(entity, entityToUpdate);
        }
    }
}
