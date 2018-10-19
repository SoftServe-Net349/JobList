using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class EmployeesRepository : Repository<Employee, int>, IEmployeesRepository
    {
        public EmployeesRepository(JobListDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
