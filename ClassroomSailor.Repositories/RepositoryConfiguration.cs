using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories.User;
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
            services.AddScoped<ITeacherEntityFactory<TeacherEntity>, TeacherEntityFactory<TeacherEntity>>();
            //services.AddScoped<IClassroomSailorUserEntityFactory<StudentEntity>, StudentEntityFactory<StudentEntity>>();
            services.AddScoped<IClassroomSailorUserRepository<TeacherEntity>, TeacherRepository<TeacherEntity>>();
            services.AddScoped<IClassroomSailorUserRepository<StudentEntity>, StudentRepository<StudentEntity>>();
        }
    }

    
}
