using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class SchoolsRepository : Repository<School, int>, ISchoolsRepository
    {
        public SchoolsRepository(JobListDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
