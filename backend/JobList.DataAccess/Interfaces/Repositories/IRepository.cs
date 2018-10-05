using JobList.Common.Interfaces.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.DataAccess.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IComparable
    {
        Task<List<TEntity>> GetRangeAsync(int index = 1,
                                          int count = 10,
                                          Expression<Func<TEntity, bool>> filter = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> GetEntityAsync(TKey Id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<List<TEntity>> GetAllEntitiesAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> CreateEntityAsync(TEntity entity);
        Task DeleteAsync(TKey Id);

        int Count { get; }
    }
}
