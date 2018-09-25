using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Interfaces.Repositories;

namespace JobList.DataAccess.Repositories
{
    public class FavoriteVacanciesRepository : Repository<FavoriteVacancy, int>, IFavoriteVacanciesRepository
    {
        public FavoriteVacanciesRepository(JobListDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
