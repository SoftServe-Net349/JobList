﻿using JobList.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobList.DataAccess.Entities
{
    public class Sample : Entity<int>
    {
        public override int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(2, 1000)]
        public int Count { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public SampleEnum SampleField { get; set; }
    }
}
