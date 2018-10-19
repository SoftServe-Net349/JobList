using Bogus;
using JobList.DataAccess.Entities;
using JobList.DataAccess.Images;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobList.DataAccess.Data
{
    public static class JobListDbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder, int amount = 10)
        {
            Faker.GlobalUniqueIndex = 0;

            var roles = new Role[]
            {
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "employee" },
                new Role { Id = 3, Name = "company" },
                new Role { Id = 4, Name = "recruiter" }
            };

            var cities = new City[]
            {
                new City {Id = 1, Name = "New York", PhotoData = CitiesImages.NewYork, PhotoMimetype = "jpg"},
                new City {Id = 2, Name = "Jersey", PhotoData = CitiesImages.Jersey, PhotoMimetype = "jpg"},
                new City {Id = 3, Name = "Atlanta", PhotoData = CitiesImages.Atlanta, PhotoMimetype = "jpg"},
                new City {Id = 4, Name = "Los Angeles", PhotoData = CitiesImages.LosAngeles, PhotoMimetype = "jpg"},
                new City {Id = 5, Name = "Boston", PhotoData = CitiesImages.Boston, PhotoMimetype = "jpg"},
                new City {Id = 6, Name = "Philadephia", PhotoData = CitiesImages.Philadephia, PhotoMimetype = "jpg"},
                new City {Id = 7, Name = "Seattle", PhotoData = CitiesImages.Seattle, PhotoMimetype = "jpg"},
                new City {Id = 8, Name = "Washington DC", PhotoData = CitiesImages.WashingtonDC, PhotoMimetype = "jpg"},
                new City {Id = 9, Name = "Las Vegas", PhotoData = CitiesImages.LasVegas, PhotoMimetype = "jpg"},
                new City {Id = 10, Name = "Phoneix", PhotoData = CitiesImages.Phoneix, PhotoMimetype = "jpg"},
                new City {Id = 11, Name = "San Francisco", PhotoData = CitiesImages.SanFrancisco, PhotoMimetype = "jpg"},
                new City {Id = 12, Name = "Chicago", PhotoData = CitiesImages.Chicago, PhotoMimetype = "jpg"}

            };

            var languages = new Language[]
            {
                new Language { Id = 1, Name = "English" },
                new Language { Id = 2, Name = "Ukrainian" },
                new Language { Id = 3, Name = "Russian" },
                new Language { Id = 4, Name = "Polish" },
                new Language { Id = 5, Name = "Greek" },
                new Language { Id = 6, Name = "Japanese" },
                new Language { Id = 7, Name = "Spanish" },
                new Language { Id = 8, Name = "Chinese" },
                new Language { Id = 9, Name = "German" },
                new Language { Id = 10, Name = "Roman" }
            };

            var schools = new School[]
            {
                new School {Id = 1, Name = "Chicago State University" },
                new School {Id = 2, Name = "Harvard University" },
                new School {Id = 3, Name = "Prinston University" },
                new School {Id = 4, Name = "Berklee College Of Arts" },
                new School {Id = 5, Name = "Stanford University" },
                new School {Id = 6, Name = "Massachusetts Institute of Technology"},
                new School {Id = 7, Name = "Columbia University" },
                new School {Id = 8, Name = "New York University" },
                new School {Id = 9, Name = "University of Arizona" },
                new School {Id = 10, Name = "Yale University" }

            };

            var workAreas = new WorkArea[]
            {
                new WorkArea{ Id = 1, Name = "IT" },
                new WorkArea{ Id = 2, Name = "Sales" },
                new WorkArea{ Id = 3, Name = "Medicine" },
                new WorkArea{ Id = 4, Name = "Marketing and Advertising" },
                new WorkArea{ Id = 5, Name = "Law and Politics" },
                new WorkArea{ Id = 6, Name = "Science" },
                new WorkArea{ Id = 7, Name = "Tourism" },
                new WorkArea{ Id = 8, Name = "Arts" },
                new WorkArea{ Id = 9, Name = "Insurance" },
                new WorkArea{ Id = 10, Name = "Real Estate" },
                new WorkArea{ Id = 11, Name = "Finances" },
                new WorkArea{ Id = 12, Name = "Media" }
            };

            var faculties = new Faculty[]
            {
                new Faculty{ Id = 1, Name = "Computer Science" },
                new Faculty{ Id = 2, Name = "Software Engineering"},
                new Faculty{ Id = 3, Name = "Applied Mathematics"},
                new Faculty{ Id = 4, Name = "Foreign Languages"},
                new Faculty{ Id = 5, Name = "International Relationships"},
                new Faculty{ Id = 6, Name = "Economics"},
                new Faculty{ Id = 7, Name = "Design"},
                new Faculty{ Id = 8, Name = "Faculty of Law"},
                new Faculty{ Id = 9, Name = "Marketing"},
                new Faculty{ Id = 10, Name = "Journalism"}
            };

            var employee = new Employee { Id = 46, FirstName = "Andrew", LastName = "Felton", Phone = "0502758765", Sex = "M", BirthData = new DateTime(1995, 8, 3), Email = "andr@gmail.com", Password = "qwerty", RoleId = 2, CityId = 8 };
            var resume = new Resume { Id = 46, WorkAreaId = 3, Courses = "Certification training", CreateDate = new DateTime(2018, 4, 5), KeySkills = "hardworking, persuasive", SoftSkills = "plastic surgery", Facebook = "www.facebook.com", FamilyState = "not married", Introduction = "Hello!" };
            var resume_language1 = new ResumeLanguage { Id = 111, ResumeId = 46, LanguageId = 10 };
            var resume_language2 = new ResumeLanguage { Id = 112, ResumeId = 46, LanguageId = 5 };
            var resume_language3 = new ResumeLanguage { Id = 113, ResumeId = 46, LanguageId = 7 };
            var experience = new Experience { Id = 65, ResumeId = 46, CompanyName = "Triomed", Position = "Surgeon", StartDate = new DateTime(2008, 12, 25), FinishDate = new DateTime(2018, 9, 5) };
            var school1 = new EducationPeriod { Id = 111, ResumeId = 46, SchoolId = 8, FacultyId = 4, StartDate = new DateTime(2002, 12, 3), FinishDate = new DateTime(2005, 6, 14) };
            var school2 = new EducationPeriod { Id = 112, ResumeId = 46, SchoolId = 5, FacultyId = 2, StartDate = new DateTime(2004, 8, 13), FinishDate = new DateTime(2007, 1, 15) };


            var companyFaker = new Faker<Company>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Name, f => f.PickRandom($"Company {f.Random.Number(999)}"))
                .RuleFor(o => o.BossName, f => f.Name.FirstName())
                .RuleFor(o => o.FullDescription, f => f.Lorem.Sentence(3))
                .RuleFor(o => o.ShortDescription, f => f.Lorem.Slug(1))
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.Phone, f => f.PickRandom($"({f.Random.Number(999)}) {f.Random.Number(999)} {f.Random.Number(9999)}"))
                .RuleFor(o => o.Site, f => f.Internet.Url())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.RoleId, f => roles[2].Id);

            var companies = companyFaker.Generate(amount).ToArray();


            var recruiterFaker = new Faker<Recruiter>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Phone, f => f.PickRandom($"({f.Random.Number(999)}) {f.Random.Number(999)} {f.Random.Number(9999)}"))
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.CompanyId, f => f.PickRandom(companies).Id)
                .RuleFor(o => o.RoleId, f => roles[3].Id);

            var recruiters = recruiterFaker.Generate(amount).ToArray();


            var vacancyFaker = new Faker<Vacancy>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Name, f => f.Name.JobTitle())
                .RuleFor(o => o.Description, f => f.Name.JobDescriptor())
                .RuleFor(o => o.Requirements, f => f.Lorem.Sentence())
                .RuleFor(o => o.Offering, f => f.Name.FullName())
                .RuleFor(o => o.BePlus, f => f.Lorem.Sentence())
                .RuleFor(o => o.IsChecked, f => f.PickRandom(true, false))
                .RuleFor(o => o.Salary, f => f.PickRandom(1000))
                .RuleFor(o => o.FullPartTime, f => f.PickRandom("Full-time", "Part-time"))
                .RuleFor(o => o.CreateDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ModDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.RecruiterId, f => f.PickRandom(recruiters).Id)
                .RuleFor(o => o.CityId, f => f.PickRandom(cities).Id)
                .RuleFor(o => o.WorkAreaId, f => f.PickRandom(workAreas).Id);

            var vacancies = vacancyFaker.Generate(5000).ToArray();


            var employeeFaker = new Faker<Employee>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Phone, f => f.PickRandom($"({f.Random.Number(999)}) {f.Random.Number(999)} {f.Random.Number(9999)}"))
                .RuleFor(o => o.Sex, f => f.PickRandom("m", "f"))
                .RuleFor(o => o.BirthData, new DateTime(2017, 3, 4))
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.RoleId, f => roles[1].Id)
                .RuleFor(o => o.CityId, f => f.PickRandom(cities).Id);
            Employee[] uu = new Employee[10];
            var employees = employeeFaker.Generate(amount + 1).ToArray();
            for (int i = 0; i < 10; i++)
            {
                uu[i] = employees[i];
            }
            employees[10] = employee;
            var resumeFaker = new Faker<Resume>()
                .RuleFor(o => o.Id, f => f.PickRandom(uu).Id)
                .RuleFor(o => o.Linkedin, f => f.Internet.Url())
                .RuleFor(o => o.Github, f => f.Internet.Url())
                .RuleFor(o => o.Facebook, f => f.Internet.Url())
                .RuleFor(o => o.Skype, f => f.Internet.Url())
                .RuleFor(o => o.Instagram, f => f.Internet.Url())
                .RuleFor(o => o.FamilyState, f => f.Lorem.Sentence(1))
                .RuleFor(o => o.SoftSkills, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Position, f => f.Lorem.Sentence(1))
                .RuleFor(o => o.Introduction, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.KeySkills, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Courses, f => f.Lorem.Sentence())
                .RuleFor(o => o.CreateDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ModDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.WorkAreaId, f => f.PickRandom(workAreas).Id);

            var resumes = resumeFaker.Generate(2).ToArray();
            resumes[1] = resume;

            Resume[] fakeResumes = new Resume[1];
            for (int i = 0; i < resumes.Length - 1; i++)
            { fakeResumes[i] = resumes[i]; }
            var experienceFaker = new Faker<Experience>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.CompanyName, f => f.Name.FullName())
                .RuleFor(o => o.Position, f => f.Lorem.Sentence())
                .RuleFor(o => o.StartDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.FinishDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ResumeId, f => f.PickRandom(fakeResumes).Id);

            var experiences = experienceFaker.Generate(amount + 1).ToArray();
            experiences[10] = experience;



            var educationPeriodFaker = new Faker<EducationPeriod>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.StartDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.FinishDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.SchoolId, f => f.PickRandom(schools).Id)
                .RuleFor(o => o.ResumeId, f => f.PickRandom(fakeResumes).Id)
                .RuleFor(o => o.FacultyId, f => f.PickRandom(faculties).Id);


            var educationPeriods = educationPeriodFaker.Generate(amount + 2).ToArray();
            educationPeriods[10] = school1;
            educationPeriods[11] = school2;


            var resumeLanguageFaker = new Faker<ResumeLanguage>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.ResumeId, f => f.PickRandom(fakeResumes).Id)
                .RuleFor(o => o.LanguageId, f => f.PickRandom(languages).Id);

            var resumeLanguages = resumeLanguageFaker.Generate(amount + 3).ToArray();
            resumeLanguages[10] = resume_language1;
            resumeLanguages[11] = resume_language2;
            resumeLanguages[12] = resume_language3;



            var favoriteVacancyFaker = new Faker<FavoriteVacancy>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.VacancyId, f => f.PickRandom(vacancies).Id)
                .RuleFor(o => o.EmployeeId, f => f.PickRandom(employees).Id);

            var favoriteVacancies = favoriteVacancyFaker.Generate(amount).ToArray();


            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<City>().HasData(cities);
            modelBuilder.Entity<Language>().HasData(languages);
            modelBuilder.Entity<Company>().HasData(companies);
            modelBuilder.Entity<School>().HasData(schools);
            modelBuilder.Entity<Faculty>().HasData(faculties);
            modelBuilder.Entity<WorkArea>().HasData(workAreas);
            modelBuilder.Entity<Recruiter>().HasData(recruiters);
            modelBuilder.Entity<Vacancy>().HasData(vacancies);
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<Resume>().HasData(resumes);
            modelBuilder.Entity<Experience>().HasData(experiences);
            modelBuilder.Entity<EducationPeriod>().HasData(educationPeriods);
            modelBuilder.Entity<ResumeLanguage>().HasData(resumeLanguages);
            modelBuilder.Entity<FavoriteVacancy>().HasData(favoriteVacancies);
        }
    }
}
