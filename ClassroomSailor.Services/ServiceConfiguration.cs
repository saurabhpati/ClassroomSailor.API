using ClassroomSailor.Entities.Student;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Services.Student;
using ClassroomSailor.Services.Teacher;
using ClassroomSailor.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace ClassroomSailor.Services
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IClassroomSailorUserService<TeacherEntity>, TeacherService>();
            services.AddSingleton<IClassroomSailorUserService<StudentEntity>, StudentService>();
        }
    }
}
