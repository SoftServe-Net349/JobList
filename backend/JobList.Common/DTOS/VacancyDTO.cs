using JobList.Common.Interfaces.Entities;
using System;

namespace JobList.Common.DTOS
{
    public class VacancyDTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Offering { get; set; }
        public string Requirements { get; set; }
        public string BePlus { get; set; }
        public bool? IsChecked { get; set; }
        public decimal? Salary { get; set; }
        public string FullPartTime { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModDate { get; set; }

        public CityDTO City { get; set; }
        public RecruiterDTO Recruiter { get; set; }
        public WorkAreaDTO WorkArea { get; set; }
    }
}
