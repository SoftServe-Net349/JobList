using JobList.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobList.DataAccess.Data
{
    public class JobListDbContext : DbContext
    {
        public JobListDbContext()
        {
        }

        public JobListDbContext(DbContextOptions<JobListDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<EducationPeriod> EducationPeriods { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<FavoriteVacancy> FavoriteVacancies { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Recruiter> Recruiters { get; set; }
        public virtual DbSet<ResumeLanguage> ResumeLanguages { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<WorkArea> WorkAreas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITIES");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_CITIES_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("COMPANIES");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ_COMPANIES_EMAIL")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_COMPANIES_NAME")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ_COMPANIES_PHONE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BossName)
                    .IsRequired()
                    .HasColumnName("BOSS_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FullDescription)
                    .IsRequired()
                    .HasColumnName("FULL_DESCRIPTION")
                    .IsUnicode(false);

                entity.Property(e => e.LogoData).HasColumnName("LOGO_DATA");

                entity.Property(e => e.LogoMimetype)
                    .HasColumnName("LOGO_MIMETYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("SHORT_DESCRIPTION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .HasColumnName("SITE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANIES_TO_ROLES");
            });

            modelBuilder.Entity<EducationPeriod>(entity =>
            {
                entity.ToTable("EDUCATION_PERIODS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("FINISH_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.ResumeId).HasColumnName("RESUME_ID");

                entity.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID");

                entity.Property(e => e.FacultyId).HasColumnName("FACULTY_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("date");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.EducationPeriods)
                    .HasForeignKey(d => d.ResumeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PK_EDUCATION_PERIODS_TO_RESUMES");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.EducationPeriods)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PK_EDUCATION_PERIODS_TO_SCHOOLS");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.EducationPeriods)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PK_EDUCATION_PERIODS_TO_FACULTIES");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("EXPERIENCES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FinishDate)
                    .HasColumnName("FINISH_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("POSITION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ResumeId).HasColumnName("RESUME_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("date");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.ResumeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXPERIENCES_TO_RESUMES");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("FACULTIES");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_FACULTIES_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FavoriteVacancy>(entity =>
            {
                entity.ToTable("FAVORITE_VACANCIES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.VacancyId).HasColumnName("VACANCY_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteVacancies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAVORITE_VACANCIES_TO_USERS");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.FavoriteVacancies)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAVORITE_VACANCIES_TO_VACANCIES");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("LANGUAGES");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_LANGUAGES_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Recruiter>(entity =>
            {
                entity.ToTable("RECRUITERS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ_RECRUITERS_EMAIL")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ_RECRUITERS_PHONE")
                    .IsUnique();

                entity.Property(e => e.LogoData).HasColumnName("LOGO_DATA");

                entity.Property(e => e.LogoMimetype)
                    .HasColumnName("LOGO_MIMETYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("COMPANY_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Recruiters)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECRUITERS_TO_COMPANIES");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Recruiters)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RECRUITERS_TO_ROLES");
            });

            modelBuilder.Entity<ResumeLanguage>(entity =>
            {
                entity.ToTable("RESUME_LANGUAGES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LanguageId).HasColumnName("LANGUAGE_ID");

                entity.Property(e => e.ResumeId).HasColumnName("RESUME_ID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ResumeLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PK_RESUME_LANGUAGES_TO_LANGUAGES");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.ResumeLanguages)
                    .HasForeignKey(d => d.ResumeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PK_RESUME_LANGUAGES_TO_RESUMES");
            });

            modelBuilder.Entity<Resume>(entity =>
            {
                entity.ToTable("RESUMES");

                entity.HasIndex(e => e.Facebook)
                    .HasName("UQ_RESUMES_FACEBOOK")
                    .IsUnique();

                entity.HasIndex(e => e.Instagram)
                    .HasName("UQ_RESUMES_INSTAGRAM")
                    .IsUnique();

                entity.HasIndex(e => e.Linkedin)
                    .HasName("UQ_RESUMES_LINKEDIN")
                    .IsUnique();

                entity.HasIndex(e => e.Skype)
                    .HasName("UQ_RESUMES_SKYPE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Courses)
                    .HasColumnName("COURSES")
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Facebook)
                    .HasColumnName("FACEBOOK")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyState)
                    .HasColumnName("FAMILY_STATE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Github)
                    .HasColumnName("GITHUB")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Instagram)
                    .HasColumnName("INSTAGRAM")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KeySkills)
                    .IsRequired()
                    .HasColumnName("KEY_SKILLS")
                    .IsUnicode(false);

                entity.Property(e => e.Linkedin)
                    .HasColumnName("LINKEDIN")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Skype)
                    .HasColumnName("SKYPE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SoftSkills)
                    .IsRequired()
                    .HasColumnName("SOFT_SKILLS")
                    .IsUnicode(false);

                entity.Property(e => e.WorkAreaId).HasColumnName("WORK_AREA_ID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Resumes)
                    .HasForeignKey<Resume>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESUMES_TO_USERS");

                entity.HasOne(d => d.WorkArea)
                    .WithMany(p => p.Resumes)
                    .HasForeignKey(d => d.WorkAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESUMES_TO_WORKAREA");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_ROLES_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("SCHOOLS");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_SCHOOLS_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ_USERS_EMAIL")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ_USERS_PHONE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");


                entity.Property(e => e.BirthData)
                    .HasColumnName("BIRTH_DATA")
                    .HasColumnType("date");

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoData).HasColumnName("PHOTO_DATA");

                entity.Property(e => e.PhotoMimeType)
                    .HasColumnName("PHOTO_MIME_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.Sex)
                    .HasColumnName("SEX")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_TO_CITIES");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_TO_ROLES");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("VACANCIES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BePlus)
                    .HasColumnName("BE_PLUS")
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CITY_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .IsUnicode(false);

                entity.Property(e => e.FullPartTime)
                    .HasColumnName("FULL_PART_TIME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsChecked).HasColumnName("IS_CHECKED");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Offering)
                    .IsRequired()
                    .HasColumnName("OFFERING")
                    .IsUnicode(false);

                entity.Property(e => e.RecruiterId).HasColumnName("RECRUITER_ID");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnName("REQUIREMENTS")
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("money");

                entity.Property(e => e.WorkAreaId).HasColumnName("WORK_AREA_ID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VACANCIES_TO_CITIES");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.RecruiterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VACANCIES_TO_RECRUITERS");

                entity.HasOne(d => d.WorkArea)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.WorkAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VACANCIES_TO_WORK_AREAS");
            });

            modelBuilder.Entity<WorkArea>(entity =>
            {
                entity.ToTable("WORK_AREAS");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_WORK_AREAS_NAME")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoData).HasColumnName("PHOTO_DATA");

                entity.Property(e => e.PhotoMimetype)
                    .HasColumnName("PHOTO_MIMETYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Seed();
        }
    }
}
