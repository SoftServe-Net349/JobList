﻿using JobList.Common.Interfaces.Entities;
using System;

namespace JobList.Common.DTOS
{
    public class ResumeDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public string Instagram { get; set; }
        public string FamilyState { get; set; }
        public string SoftSkills { get; set; }
        public string KeySkills { get; set; }
        public string Courses { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModDate { get; set; }
    }
}