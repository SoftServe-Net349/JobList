using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class InvitationsRepository : Repository<Invitation, int>, IInvitationsRepository
    {
        public InvitationsRepository(JobListDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
