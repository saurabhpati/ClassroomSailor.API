using ClassroomSailor.Entities.Student;
using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Entities.Teacher;
using Microsoft.EntityFrameworkCore;

namespace ClassroomSailor.Repositories
{
    public class ClassroomSailorDbContext : DbContext
    {
        public ClassroomSailorDbContext(DbContextOptions<ClassroomSailorDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=SAURABH-PC\\SQLEXPRESS;Database=ClassroomSailor;Integrated Security=True;", options => options.MigrationsAssembly("ClassroomSailor.Repositories"));
        }

        public DbSet<TeacherEntity> Teachers { get; set; }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<SubjectEntity> Subjects { get; set; }
    }
}
