using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Repositories.User
{
    public class TeacherRepository : ClassroomSailorUserRepository<TeacherEntity>
    {
        public TeacherRepository(ClassroomSailorDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<TeacherEntity>> GetAllAsync()
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Teachers as IQueryable<TeacherEntity>);
            }
        }

        public override async Task<TeacherEntity> GetByEmailAsync(String email)
        {
            using (this.Database)
            {
                return await Task.FromResult(
                    this.Database.Teachers
                    .FirstOrDefault(teacher => String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
            }
        }

        public async override Task<TeacherEntity> GetByIdAsync(Int64 id)
        {
            using (this.Database)
            {
                return await this.Database.Teachers.FindAsync(id);
            }
        }
    }
}
