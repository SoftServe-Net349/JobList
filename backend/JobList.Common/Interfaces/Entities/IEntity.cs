﻿
namespace JobList.Common.Interfaces.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
