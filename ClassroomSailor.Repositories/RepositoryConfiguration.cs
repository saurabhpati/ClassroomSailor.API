using ClassroomSailor.Entities.Student;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Repositories.Student;
using ClassroomSailor.Repositories.Teacher;
using ClassroomSailor.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassroomSailor.Repositories
{
    public static class RepositoryConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            /* Repositores are injected with scoped lifetimes so that dbcontext can be disposed after a transaction.
             * If injected with singleton lifetime, the dbcontext may never get disposed.
             */
            services.AddSingleton<DbContextOptions<ClassroomSailorDbContext>>();
            services.AddSingleton<ClassroomSailorDbContext>();
            services.AddSingleton<IClassroomSailorUserRepository<TeacherEntity>, TeacherRepository>();
            services.AddSingleton<IClassroomSailorUserRepository<StudentEntity>, StudentRepository>();
            services.AddDbContext<ClassroomSailorDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default"), sqlOptions => 
                    sqlOptions.MigrationsAssembly("ClassroomSailor.Repositories")));
        }
    }
}
