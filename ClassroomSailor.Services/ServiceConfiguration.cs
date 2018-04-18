using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace ClassroomSailor.Services
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ITeacherEntityFactory<TeacherEntity>, TeacherEntityFactory<TeacherEntity>>();
            services.AddScoped<IStudentEntityFactory<StudentEntity>, StudentEntityFactory<StudentEntity>>();
            services.AddScoped<IClassroomSailorUserService<StudentEntity>, StudentService<StudentEntity>>();
            services.AddScoped<IClassroomSailorUserService<TeacherEntity>, TeacherService<TeacherEntity>>();
        }
    }
}
