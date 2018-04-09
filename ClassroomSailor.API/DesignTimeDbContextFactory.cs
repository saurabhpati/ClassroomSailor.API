using System.IO;
using ClassroomSailor.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClassroomSailor.API
{
    /// <summary>
    /// Design-time service for ClassroomSailorDbContext.
    /// <para>
    /// Since the ClassroomSailorDbContext is present in a different assembly, 
    /// EF will look for implementations of IDesignTimeDbContextFactory<ClassroomSailorDbContext>
    /// when adding migrations or updating the database. The DB Context will be created here.
    /// </para>
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClassroomSailorDbContext>
    {
        /// <summary>
        /// Creates the Database Context for the app at design-time service.
        /// </summary>
        /// <param name="args">Arguments to the function</param>
        /// <returns>The application database context</returns>
        public ClassroomSailorDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            DbContextOptionsBuilder<ClassroomSailorDbContext> builder = new DbContextOptionsBuilder<ClassroomSailorDbContext>();
            builder.UseSqlServer(configRoot.GetConnectionString("Default"), options => options.MigrationsAssembly("ClassroomSailor.Repositories"));
            return new ClassroomSailorDbContext(builder.Options);
        }
    }
}
