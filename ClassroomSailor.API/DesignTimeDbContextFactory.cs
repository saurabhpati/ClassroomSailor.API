using System.IO;
using ClassroomSailor.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClassroomSailor.API
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClassroomSailorDbContext>
    {
        public ClassroomSailorDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            DbContextOptionsBuilder<ClassroomSailorDbContext> builder = new DbContextOptionsBuilder<ClassroomSailorDbContext>();
            builder.UseSqlServer(configRoot.GetConnectionString("Default"), options => options.MigrationsAssembly("ClassroomSailor.DAL"));
            return new ClassroomSailorDbContext(builder.Options);
        }
    }
}
