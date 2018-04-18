using ClassroomSailor.API.Models.User;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Repositories;
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
            services.AddScoped<ITeacherEntityFactory<TeacherApiModel>, TeacherEntityFactory<TeacherApiModel>>();
            services.AddScoped<IStudentEntityFactory<StudentApiModel>, StudentEntityFactory<StudentApiModel>>();
            services.AddScoped<IClassroomSailorUserService<StudentApiModel>, StudentService<StudentApiModel>>();
            services.AddScoped<IClassroomSailorUserService<TeacherApiModel>, TeacherService<TeacherApiModel>>();
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

            app.UseMvc();
        }
    }
}
