using Bogus;
using JobList.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                new Role { Id = 2, Name = "user" },
                new Role { Id = 3, Name = "company" },
                new Role { Id = 4, Name = "recruiter" }
            };

            var cities = new City[]
            {
                new City {Id = 1, Name = "New York City"},
                new City {Id = 2, Name = "Jersey City"},
                new City {Id = 3, Name = "Atlanta"},
                new City {Id = 4, Name = "Los Angeles"},
                new City {Id = 5, Name = "Boston"},
                new City {Id = 6, Name = "Philadephia"},
                new City {Id = 7, Name = "Seattle" },
                new City {Id = 8, Name = "Washington DC"},
                new City {Id = 9, Name = "Las Vegas"},
                new City {Id = 10, Name = "Phoneix"},
                new City {Id = 11, Name = "San Francisco"},
                new City {Id = 12, Name = "Chicago"}

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

            var companyFaker = new Faker<Company>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Name, f => f.PickRandom($"Company № {f.Random.Number(999)}"))
                .RuleFor(o => o.BossName, f => f.Name.FirstName())
                .RuleFor(o => o.FullDescription, f => f.Lorem.Sentence())
                .RuleFor(o => o.ShortDescription, f => f.Lorem.Slug(1))
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.Phone, f => f.PickRandom($"073 {f.Random.Number(9999)}"))
                .RuleFor(o => o.Site, f => f.Internet.Url())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.RoleId, f => f.PickRandom(roles).Id);

            var companies = companyFaker.Generate(amount).ToArray();


            var recruiterFaker = new Faker<Recruiter>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Phone, f => f.PickRandom($"073 {f.Random.Number(9999)}"))
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.CompanyId, f => f.PickRandom(companies).Id)
                .RuleFor(o => o.RoleId, f => f.PickRandom(roles).Id);

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

            var vacancies = vacancyFaker.Generate(amount).ToArray();


            var userFaker = new Faker<User>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Phone, f => f.PickRandom($"073 {f.Random.Number(9999)}"))
                .RuleFor(o => o.Sex, f => f.PickRandom("m", "f"))
                .RuleFor(o => o.BirthData, new DateTime(2017, 3, 4))
                .RuleFor(o => o.Address, f => f.Address.StreetName())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.RoleId, f => f.PickRandom(roles).Id)
                .RuleFor(o => o.CityId, f => f.PickRandom(cities).Id);

            var users = userFaker.Generate(amount).ToArray();

            var resumeFaker = new Faker<Resume>()
                .RuleFor(o => o.Id, f => f.PickRandom(users).Id)
                .RuleFor(o => o.Linkedin, f => f.Internet.Url())
                .RuleFor(o => o.Github, f => f.Internet.Url())
                .RuleFor(o => o.Facebook, f => f.Internet.Url())
                .RuleFor(o => o.Skype, f => f.Internet.Url())
                .RuleFor(o => o.Instagram, f => f.Internet.Url())
                .RuleFor(o => o.FamilyState, f => f.Lorem.Sentence(1))
                .RuleFor(o => o.SoftSkills, f => f.Lorem.Sentence())
                .RuleFor(o => o.KeySkills, f => f.Lorem.Sentence())
                .RuleFor(o => o.Courses, f => f.Lorem.Sentence())
                .RuleFor(o => o.CreateDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ModDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.WorkAreaId, f => f.PickRandom(workAreas).Id);

            var resumes = resumeFaker.Generate(1).ToArray();


            var experienceFaker = new Faker<Experience>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.CompanyName, f => f.Name.FullName())
                .RuleFor(o => o.Position, f => f.Lorem.Sentence())
                .RuleFor(o => o.StartDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.FinishDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ResumeId, f => f.PickRandom(resumes).Id);

            var experiences = experienceFaker.Generate(amount).ToArray();


            var educationPeriodFaker = new Faker<EducationPeriod>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.StartDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.FinishDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.SchoolId, f => f.PickRandom(schools).Id)
                .RuleFor(o => o.ResumeId, f => f.PickRandom(resumes).Id)
                .RuleFor(o => o.FacultyId, f => f.PickRandom(faculties).Id);
            

            var educationPeriods = educationPeriodFaker.Generate(amount).ToArray();


            var resumeLanguageFaker = new Faker<ResumeLanguage>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.ResumeId, f => f.PickRandom(resumes).Id)
                .RuleFor(o => o.LanguageId, f => f.PickRandom(languages).Id);

            var resumeLanguages = resumeLanguageFaker.Generate(amount).ToArray();


            var favoriteVacancyFaker = new Faker<FavoriteVacancy>()
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.VacancyId, f => f.PickRandom(vacancies).Id)
                .RuleFor(o => o.UserId, f => f.PickRandom(users).Id);

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
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Resume>().HasData(resumes);
            modelBuilder.Entity<Experience>().HasData(experiences);
            modelBuilder.Entity<EducationPeriod>().HasData(educationPeriods);
            modelBuilder.Entity<ResumeLanguage>().HasData(resumeLanguages);
            modelBuilder.Entity<FavoriteVacancy>().HasData(favoriteVacancies);
        }
    }
}
