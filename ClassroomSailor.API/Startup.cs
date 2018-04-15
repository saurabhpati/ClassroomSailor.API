using ClassroomSailor.API.Models.User;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Repositories;
using ClassroomSailor.Repositories.User;
using ClassroomSailor.Services;
using ClassroomSailor.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<ClassroomSailorDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Default")));
            services.AddScoped<IClassroomSailorUserService<StudentApiModel>, ClassroomSailorUserService<StudentApiModel>>();
            services.AddScoped<IClassroomSailorUserService<TeacherApiModel>, ClassroomSailorUserService<TeacherApiModel>>();
            services.AddScoped<IClassroomSailorUserRepository<TeacherApiModel>, TeacherRepository<TeacherApiModel>>();
            services.AddScoped<IClassroomSailorUserRepository<StudentApiModel>, StudentRepository<StudentApiModel>>();
            services.AddScoped<ITeacherEntityFactory<TeacherApiModel>, TeacherEntityFactory<TeacherApiModel>>();
            //services.AddScoped<IClassroomSailorUserEntityFactory<StudentEntity>, StudentEntityFactory<StudentEntity>>();
            RepositoryConfiguration.Configure(services, this.Configuration);
            ServiceConfiguration.Configure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
