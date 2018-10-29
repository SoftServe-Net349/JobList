using JobList.DataAccess.Interfaces.Repositories;
using System.Threading.Tasks;

namespace JobList.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ICitiesRepository CitiesRepository { get; }
        ICompaniesRepository CompaniesRepository { get; }
        IEducationPeriodsRepository EducationPeriodsRepository { get; }
        IExperiencesRepository ExperiencesRepository { get; }
        IFacultiesRepository FacultiesRepository { get; }
        IFavoriteVacanciesRepository FavoriteVacanciesRepository { get; }
        ILanguagesRepository LanguagesRepository { get; }
        IRecruitersRepository RecruitersRepository { get; }
        IResumeLanguagesRepository ResumeLanguagesRepository { get; }
        IResumesRepository ResumesRepository { get; }
        IRolesRepository RolesRepository { get; }
        ISchoolsRepository SchoolsRepository { get; }
        IEmployeesRepository EmployeesRepository { get; }
        IVacanciesRepository VacanciesRepository { get; }
        IWorkAreasRepository WorkAreasRepository { get; }
        IInvitationsRepository InvitationsRepository { get; }

        Task<bool> SaveAsync();
    }
}
