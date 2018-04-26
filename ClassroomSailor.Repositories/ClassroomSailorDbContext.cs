using Microsoft.EntityFrameworkCore;

namespace ClassroomSailor.Repositories
{
    public class ClassroomSailorDbContext : DbContext
    {
        public ClassroomSailorDbContext(DbContextOptions<ClassroomSailorDbContext> options) : base(options)
        {
        }
    }
}
