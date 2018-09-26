using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class CitiesRepository : Repository<City, int>, ICitiesRepository
    {
        public CitiesRepository(JobListDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
