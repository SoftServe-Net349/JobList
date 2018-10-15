using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using JobList.Common.Errors;
using JobList.Common.Interfaces.Entities;
using JobList.Common.Pagination;
using JobList.DataAccess.Data;
using JobList.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace JobList.DataAccess.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IComparable
    {
        protected readonly JobListDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected readonly IMapper _mapper;

        public int Count { get { return _dbSet.Count(); } }

        public Repository(JobListDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetRangeAsync(Expression<Func<TEntity, bool>> filter = null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                       PaginationUrlQuery urlQuery = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if(urlQuery != null)
            {
                query = query.Skip(urlQuery.PageSize * (urlQuery.PageNumber - 1))
                    .Take(urlQuery.PageSize);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null,
                                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }

            return await query.FirstOrDefaultAsync();
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

        public async Task<List<TEntity>> GetAllEntitiesAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetEntityAsync(TKey Id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            query = query.Where(e => e.Id.CompareTo(Id) == 0);

            if (query.Count() < 1)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, $"Entity with id: {Id} not found when trying to get entity.");
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().AnyAsync(predicate);
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

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet.AsNoTracking().CountAsync();
            }

            return _dbSet.AsNoTracking().CountAsync(predicate);
        }
    }
}
