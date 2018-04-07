using ClassroomSailor.Entities.Student;
using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Entities.Teacher;
using Microsoft.EntityFrameworkCore;

namespace ClassroomSailor.DAL.DatabaseContext
{
    public class ClassroomSailorDbContext : DbContext
    {
        public ClassroomSailorDbContext(DbContextOptions<ClassroomSailorDbContext> options) : base(options)
        {
        }

        public DbSet<TeacherEntity> Teachers { get; set; }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<SubjectEntity> Subjects { get; set; }
    }
}
