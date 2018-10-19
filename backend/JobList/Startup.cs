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
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using JobList.Common.Options;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JobList.Common.DTOS;
using Microsoft.AspNetCore.Authorization;
using JobList.AuthorizationHandlers;

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
            // Connection to db
            services.AddDbContext<JobListDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithExposedHeaders("X-Pagination");
            }));

            var tokensSection = Configuration.GetSection("Tokens");

            // Configuring JobListTokenOptions
            services.Configure<JobListTokenOptions>(o => 
                {
                    o.Issuer = tokensSection["Issuer"];
                    o.Audience = tokensSection["Audience"];
                    o.Access_Token_Lifetime = Convert.ToInt32(tokensSection["Access_Token_Lifetime"]);
                    o.Refresh_Token_Lifetime = Convert.ToInt32(tokensSection["Refresh_Token_Lifetime"]);
                    o.Security_Key = tokensSection["Key"];
                });

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
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IVacanciesService, VacanciesService>();
            services.AddTransient<IWorkAreasService, WorkAreasService>();
            services.AddTransient<ITokensService<EmployeeDTO>, EmployeeTokensService>();
            services.AddTransient<ITokensService<CompanyDTO>, CompanyTokensService>();
            services.AddTransient<ITokensService<RecruiterDTO>, RecruiterTokensService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Authorization User as an Owner
            services.AddAuthorization(options =>
            {
                options.AddPolicy("OwnerPolicy", policy =>
                    policy.Requirements.Add(new SameOwnerRequirement()));
            });

            // Add your authorization handlers here
            services.AddSingleton<IAuthorizationHandler, OwnerAuthorizationHandler>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokensSection["Issuer"],
                        ValidAudience = tokensSection["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokensSection["Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.ImplicitlyValidateChildProperties = true;
                                // fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.RegisterValidatorsFromAssemblyContaining<CityValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<CompanyValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<ResumeValidator>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddMvc()
                .AddJsonOptions(
                 options => options.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
            app.UseAuthentication();
            app.UseMvc();
        }

        public virtual IServiceCollection InitializeAutomapper(IServiceCollection services)
        {
            // Used in older versions
            // ServiceCollectionExtensions.UseStaticRegistration = false;

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<CitiesProfile>();
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<EducationPeriodProfile>();
                cfg.AddProfile<ExperienceProfile>();
                cfg.AddProfile<FacultyProfile>();
                cfg.AddProfile<FavoriteVacancyProfile>();
                cfg.AddProfile<LanguageProfile>();
                cfg.AddProfile<RecruiterProfile>();
                cfg.AddProfile<ResumeProfile>();
                cfg.AddProfile<ResumeLanguageProfile>();
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<SchoolProfile>();
                cfg.AddProfile<EmployeeProfile>();
                cfg.AddProfile<VacancyProfile>();
                cfg.AddProfile<WorkAreaProfile>();
            }); // Scoped Lifetime!

            return services;
        }
    }
}
