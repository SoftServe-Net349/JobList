using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using JobList.Common.Validators;
using JobList.BusinessLogic.Interfaces;
using JobList.BusinessLogic.MappingProfiles;
using JobList.BusinessLogic.Services;
using JobList.DataAccess;
using JobList.DataAccess.Data;
using JobList.DataAccess.Interfaces;
using FluentValidation.AspNetCore;
using JobList.Common.Validators;
using AutoMapper;
using JobList.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace JobList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //connection to db
            services.AddDbContext<JobListDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
            services.AddMvc()
                            .AddFluentValidation(fv =>
                            {
                                fv.ImplicitlyValidateChildProperties = true;
                                // fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                                fv.RegisterValidatorsFromAssemblyContaining<CityValidator>();
                            })
                            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //services.AddDbContext<JobListDbContext>();
            //services.AddScoped<DbContext>(sp => sp.GetService<JobListDbContext>());


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add your services here
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<IEducationPeriodsService, EducationPeriodsService>();
            services.AddTransient<IExperiencesService, ExperiencesService>();
            services.AddTransient<IFacultiesService, FacultiesService>();
            services.AddTransient<IFavoriteVacanciesService, FavoriteVacanciesService>();
            services.AddTransient<ILanguagesService, LanguagesService>();
            services.AddTransient<IRecruitersService, RecruitersService>();
            services.AddTransient<IResumeLanguagesService, ResumeLanguagesService>();
            services.AddTransient<IResumesService, ResumesService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<ISchoolsService, SchoolsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IVacanciesService, VacanciesService>();
            services.AddTransient<IWorkAreasService, WorkAreasService>();

            InitializeAutomapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseHttpStatusCodeExceptionMiddleware();

            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }

        public virtual IServiceCollection InitializeAutomapper(IServiceCollection services)
        {
            // Used in older versions
            // ServiceCollectionExtensions.UseStaticRegistration = false;

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CitiesProfile>();
            }); // Scoped Lifetime!

            return services;
        }
    }
}
