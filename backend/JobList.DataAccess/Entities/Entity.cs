using JobList.Common.Interfaces.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobList.DataAccess.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey> where TKey : IComparable
    {
        [Key]
        public abstract TKey Id { get; set; }
    }
}
