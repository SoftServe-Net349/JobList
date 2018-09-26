using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class VacanciesRepository : Repository<Vacancy, int>, IVacanciesRepository
    {
        public VacanciesRepository(JobListDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
