using AutoMapper;
using JobList.DataAccess.Data;
using JobList.DataAccess.Interfaces;
using JobList.DataAccess.Interfaces.Repositories;
using JobList.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobList.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JobListDbContext _context;
        private readonly IMapper _mapper;

        private ICitiesRepository _citiesRepository;
        private ICompaniesRepository _companiesRepository;
        private IEducationPeriodsRepository _educationPeriods;
        private IExperiencesRepository _experiencesRepository;
        private IFacultiesRepository _facultiesRepository;
        private IFavoriteVacanciesRepository _favoriteVacanciesRepository;
        private ILanguagesRepository _languagesRepository;
        private IRecruitersRepository _recruitersRepository;
        private IResumeLanguagesRepository _resumeLanguagesRepository;
        private IResumesRepository _resumesRepository;
        private IRolesRepository _rolesRepository;
        private ISchoolsRepository _schoolsRepository;
        private IUsersRepository _usersRepository;
        private IVacanciesRepository _vacanciesRepository;
        private IWorkAreasRepository _workAreasRepository;

        public UnitOfWork(JobListDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICitiesRepository CitiesRepository
        {
            get
            {
                if(_citiesRepository != null)
                {
                    _citiesRepository = new CitiesRepository(_context, _mapper);
                }

                return _citiesRepository;
            }
        }

        public ICompaniesRepository CompaniesRepository
        {
            get
            {
                if (_companiesRepository != null)
                {
                    _companiesRepository = new CompaniesRepository(_context, _mapper);
                }

                return _companiesRepository;
            }
        }

        public IEducationPeriodsRepository EducationPeriodsRepository
        {
            get
            {
                if (_educationPeriods != null)
                {
                    _educationPeriods = new EducationPeriodsRepository(_context, _mapper);
                }

                return _educationPeriods;
            }
        }
    
        public IExperiencesRepository ExperiencesRepository
        {
            get
            {
                if (_experiencesRepository != null)
                {
                    _experiencesRepository = new ExperiencesRepository(_context, _mapper);
                }

                return _experiencesRepository;
            }
        }

        public IFacultiesRepository FacultiesRepository
        {
            get
            {
                if (_facultiesRepository != null)
                {
                    _facultiesRepository = new FacultiesRepository(_context, _mapper);
                }

                return _facultiesRepository;
            }
        }

        public IFavoriteVacanciesRepository FavoriteVacanciesRepository
        {
            get
            {
                if (_favoriteVacanciesRepository != null)
                {
                    _favoriteVacanciesRepository = new FavoriteVacanciesRepository(_context, _mapper);
                }

                return _favoriteVacanciesRepository;
            }
        }

        public ILanguagesRepository LanguagesRepository
        {
            get
            {
                if (_languagesRepository != null)
                {
                    _languagesRepository = new LanguagesRepository(_context, _mapper);
                }

                return _languagesRepository;
            }
        }

        public IRecruitersRepository RecruitersRepository
        {
            get
            {
                if (_recruitersRepository != null)
                {
                    _recruitersRepository = new RecruitersRepository(_context, _mapper);
                }

                return _recruitersRepository;
            }
        }

        public IResumeLanguagesRepository ResumeLanguagesRepository
        {
            get
            {
                if (_resumeLanguagesRepository != null)
                {
                    _resumeLanguagesRepository = new ResumeLanguagesRepository(_context, _mapper);
                }

                return _resumeLanguagesRepository;
            }
        }

        public IResumesRepository ResumesRepository
        {
            get
            {
                if (_resumesRepository != null)
                {
                    _resumesRepository = new ResumesRepository(_context, _mapper);
                }

                return _resumesRepository;
            }
        }

        public IRolesRepository RolesRepository
        {
            get
            {
                if (_rolesRepository != null)
                {
                    _rolesRepository = new RolesRepository(_context, _mapper);
                }

                return _rolesRepository;
            }
        }

        public ISchoolsRepository SchoolsRepository
        {
            get
            {
                if (_schoolsRepository != null)
                {
                    _schoolsRepository = new SchoolsRepository(_context, _mapper);
                }

                return _schoolsRepository;
            }
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                if (_usersRepository != null)
                {
                    _usersRepository = new UsersRepository(_context, _mapper);
                }

                return _usersRepository;
            }
        }

        public IVacanciesRepository VacanciesRepository
        {
            get
            {
                if (_vacanciesRepository != null)
                {
                    _vacanciesRepository = new VacanciesRepository(_context, _mapper);
                }

                return _vacanciesRepository;
            }
        }

        public IWorkAreasRepository WorkAreasRepository
        {
            get
            {
                if (_workAreasRepository != null)
                {
                    _workAreasRepository = new WorkAreasRepository(_context, _mapper);
                }

                return _workAreasRepository;
            }
        }


        public async Task<bool> SaveAsync()
        {
            try
            {
                var changes = _context.ChangeTracker.Entries().Count(
                    p => p.State == EntityState.Modified || p.State == EntityState.Deleted
                                                         || p.State == EntityState.Added);
                if (changes == 0) return true;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // DbSet?.Local?.Clear();
                    _context?.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AbstractRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
