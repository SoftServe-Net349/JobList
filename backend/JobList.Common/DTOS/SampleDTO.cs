using JobList.Common.Enums;
using JobList.Common.Interfaces.Entities;
using System;

namespace JobList.Common.DTOS
{
    public class SampleDTO : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public DateTime DateOfCreation { get; set; }

        public SampleEnum SampleField { get; set; }
    }
}
