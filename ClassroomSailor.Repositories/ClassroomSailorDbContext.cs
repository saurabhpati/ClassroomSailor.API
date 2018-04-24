using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ClassroomSailor.Repositories
{
    public class ClassroomSailorDbContext : DbContext
    {
        public ClassroomSailorDbContext(DbContextOptions<ClassroomSailorDbContext> options) : base(options)
        {
        }

        public ClassroomSailorDbContext()
        {

        }

        public virtual DbSet<TeacherEntity> Teachers { get; set; }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<SubjectEntity> Subjects { get; set; }
    }
}
