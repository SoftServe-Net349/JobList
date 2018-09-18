using JobList.Common.Interfaces.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobList.DataAccess.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> GetEntityAsync(TKey Id);
        Task<List<TEntity>> GetAllEntitiesAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> CreateEntityAsync(TEntity entity);
        Task DeleteAsync(TKey Id);
    }
}
