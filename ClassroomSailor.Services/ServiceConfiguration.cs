using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace ClassroomSailor.Services
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IClassroomSailorUserService<StudentEntity>, ClassroomSailorUserService<StudentEntity>>();
            services.AddScoped<IClassroomSailorUserService<TeacherEntity>, TeacherService<TeacherEntity>>();
        }
    }
}
