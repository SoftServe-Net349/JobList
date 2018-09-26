using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class FacultiesRepository : Repository<Faculty, int>, IFacultiesRepository
    {
        public FacultiesRepository(JobListDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
