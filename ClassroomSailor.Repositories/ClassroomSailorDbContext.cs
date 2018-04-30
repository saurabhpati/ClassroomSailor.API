using ClassroomSailor.Entities.Classroom;
using ClassroomSailor.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassroomSailor.Repositories
{
    public class ClassroomSailorDbContext : IdentityDbContext<ClassroomSailorUserEntity>
    {
        public ClassroomSailorDbContext(DbContextOptions<ClassroomSailorDbContext> options) : base(options)
        {
        }

        public DbSet<ClassroomEnity> Classrooms { get; set; }
    }
}
