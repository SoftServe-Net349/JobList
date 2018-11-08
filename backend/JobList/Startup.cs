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
using Microsoft.AspNetCore.Mvc.Authorization;
using JobList.Providers;
using Microsoft.AspNetCore.SignalR;
using JobList.BusinessLogic.Hubs;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Identity.UI.Services;
using JobList.BusinessLogic.Providers;

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
            // Connection to DataBase
            //services.AddDbContext<JobListDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // For Tests
            services.AddDbContext<JobListDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=JOB_LIST_DB;Integrated Security=True;MultipleActiveResultSets=True;"));


            // Add Cors policy
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .WithExposedHeaders("X-Pagination");
            }));

            // Configuring FacebookAuthOptions
            var facebookAuthSection = Configuration.GetSection("FacebookAuth");

            services.Configure<FacebookAuthOptions>(o =>
                {
                    o.AppId = facebookAuthSection["AppId"];
                    o.AppSecret = facebookAuthSection["AppSecret"];
                });

            // Configuring JobListTokenOptions
            var tokensSection = Configuration.GetSection("Tokens");

            services.Configure<JobListTokenOptions>(o => 
                {
                    o.Issuer = tokensSection["Issuer"];
                    o.Audience = tokensSection["Audience"];
                    o.Access_Token_Lifetime = Convert.ToInt32(tokensSection["Access_Token_Lifetime"]);
                    o.Security_Key = tokensSection["Key"];
                });


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
            services.AddTransient<IInvitationsService, InvitationsService>();
            services.AddTransient<IEmployeeTokensService, EmployeeTokensService>();
            services.AddTransient<ITokensService<CompanyDTO>, CompanyTokensService>();
            services.AddTransient<ITokensService<RecruiterDTO>, RecruiterTokensService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IEmailSender, EmailProvider>(i =>
               new EmailProvider(
                   Configuration["EmailSender:Host"],
                   Configuration.GetValue<int>("EmailSender:Port"),
                   Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   Configuration["EmailSender:UserName"],
                   Configuration["EmailSender:Password"]
               )
           );

            // Add your authorization handlers here
            services.AddSingleton<IAuthorizationHandler, OwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, AdministratorsAuthorizationHandler>();

            // Add authentication and set up validation parameters
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
                        //ValidateIssuer = true,
                        //ValidateAudience = true,
                        //ValidateLifetime = true,
                        //ValidateIssuerSigningKey = true,
                        //ValidIssuer = tokensSection["Issuer"],
                        //ValidAudience = tokensSection["Audience"],
                        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokensSection["Key"])),
                        //ClockSkew = TimeSpan.Zero

                        // For Tests
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://localhost:56681/",
                        ValidAudience = "http://localhost:56681/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("TokensSuperSecretKey")),
                        ClockSkew = TimeSpan.Zero

                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["token"].ToString();

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/invitationHub")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddSignalR();
            // Add user id provider
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

            services.AddMvc(config =>
            {
                // using Microsoft.AspNetCore.Mvc.Authorization;
                // using Microsoft.AspNetCore.Authorization;
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })

                .AddFluentValidation(GetRegisteredFluentValidators())
                .AddJsonOptions(
                 options => options.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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
            app.UseSignalR(routes =>
            {
                routes.MapHub<InvitationHub>("/invitationHub");
            });
            app.UseMvc();
        }

        public virtual Action<FluentValidationMvcConfiguration> GetRegisteredFluentValidators()
        {
            return fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                // fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                fv.RegisterValidatorsFromAssemblyContaining<CityValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<CompanyValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<EducationPeriodValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<CompanyUpdateValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<EmployeeUpdateValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<RecruiterValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<RecruiterUpdateValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<WorkAreaValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<LanguageValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<FacultyValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<FavoriteVacancyValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<ResumeLanguageValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<ResumeValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<RoleValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<SchoolValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<VacancyValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<ExperienceValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<InvitationValidator>();
            };
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
                cfg.AddProfile<InvitationProfile>();
            }); // Scoped Lifetime!

            return services;
        }
    }
}
