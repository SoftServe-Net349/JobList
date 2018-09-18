using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    class SamplesRepository : Repository<Sample, int>, ISamplesRepository
    {
        public SamplesRepository(JobListDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
