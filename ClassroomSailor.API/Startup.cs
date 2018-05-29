using ClassroomSailor.API.Models.Classroom;
using ClassroomSailor.API.Models.User;
using ClassroomSailor.Entities.Classroom;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories;
using ClassroomSailor.Repositories.Classroom;
using ClassroomSailor.Repositories.User;
using ClassroomSailor.Services.Account;
using ClassroomSailor.Services.Classroom;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassroomSailor.API
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
            services.AddMvc();
            services
                .AddDbContext<ClassroomSailorDbContext>(options =>
                    options.UseSqlServer(this.Configuration.GetConnectionString("Default")))
                .AddIdentity<ClassroomSailorUserEntity, IdentityRole>(option => option.Lockout.MaxFailedAccessAttempts = 5)
                .AddEntityFrameworkStores<ClassroomSailorDbContext>()
                .AddDefaultTokenProviders(); ;

            services.AddScoped<UserManager<ClassroomSailorUserEntity>>()
                    .AddScoped<SignInManager<ClassroomSailorUserEntity>>()
                    .AddScoped<IdentityRole>()
                    .AddScoped<IAccountService<ClassroomSailorUserApiModel>, AccountService<ClassroomSailorUserApiModel>>()
                    .AddScoped<IClassroomSailorUserService<ClassroomSailorUserEntity>, ClassroomSailorUserService<ClassroomSailorUserEntity>>()
                    .AddScoped<IClassroomService<ClassroomApiModel>, ClassroomService<ClassroomApiModel>>()
                    .AddScoped<IClassroomSailorUserRepository<ClassroomSailorUserEntity>, ClassroomSailorUserRepository>()
                    .AddScoped<IClassroomRepository<ClassroomEnity>, ClassroomRepository>()
                    .AddScoped<IClassroomSailorUserEntityFactory<ClassroomSailorUserApiModel>, ClassroomSailorUserEntityFactory<ClassroomSailorUserApiModel>>()
                    .AddScoped<IClassroomEntityFactory<ClassroomApiModel>, ClassroomEntityFactory<ClassroomApiModel>>()
                    .AddTransient<IUserClaimsPrincipalFactory<ClassroomSailorUserEntity>, ClassroomSailorUserClaimsPrincipalFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc()
               .UseAuthentication();
        }
    }
}
