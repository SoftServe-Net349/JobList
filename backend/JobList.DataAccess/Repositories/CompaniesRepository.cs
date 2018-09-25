using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class CompaniesRepository : Repository<Company, int>, ICompaniesRepository
    {
        public CompaniesRepository(JobListDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }   
    }
}
