﻿using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories;
using ClassroomSailor.Services;
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
                    .AddTransient<IUserClaimsPrincipalFactory<ClassroomSailorUserEntity>, ClassroomSailorUserClaimsPrincipalFactory>();
                    
            RepositoryConfiguration.Configure(services);
            ServiceConfiguration.Configure(services);
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
