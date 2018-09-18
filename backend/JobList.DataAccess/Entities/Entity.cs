using JobList.Common.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobList.DataAccess.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        [Key]
        public abstract TKey Id { get; set; }
    }
}
