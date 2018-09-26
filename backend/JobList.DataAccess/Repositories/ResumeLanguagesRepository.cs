using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class ResumeLanguagesRepository : Repository<ResumeLanguage, int>, IResumeLanguagesRepository
    {
        public ResumeLanguagesRepository(JobListDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
