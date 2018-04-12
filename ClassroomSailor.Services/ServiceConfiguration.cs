using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace ClassroomSailor.Services
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureUserServices<StudentEntity>(services);
            ConfigureUserServices<TeacherEntity>(services);
        }

        private static void ConfigureUserServices<T>(IServiceCollection services) where T: ClassroomSailorUserEntity
        {
            services.AddSingleton<IClassroomSailorUserService<T>, ClassroomSailorUserService<T>>();
        }
    }
}
