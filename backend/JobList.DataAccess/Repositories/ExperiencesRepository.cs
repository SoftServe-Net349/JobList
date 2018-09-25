using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class ExperiencesRepository : Repository<Experience, int>, IExperiencesRepository
    {
        public ExperiencesRepository(JobListDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
