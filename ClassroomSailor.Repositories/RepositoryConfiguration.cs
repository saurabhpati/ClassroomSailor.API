using Microsoft.Extensions.DependencyInjection;

namespace ClassroomSailor.Repositories
{
    public static class RepositoryConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            /* Repositores are injected with scoped lifetimes so that dbcontext can be disposed after a transaction.
             * If injected with singleton lifetime, the dbcontext may never get disposed.
             */
        }
    }
}
