using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Repositories.User
{
    public class StudentRepository : ClassroomSailorUserRepository<StudentEntity>
    {
        public StudentRepository(ClassroomSailorDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Students as IQueryable<StudentEntity>);
            }
        }

        public override async Task<StudentEntity> GetByEmailAsync(String email)
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Students.FirstOrDefault(student => String.Compare(student.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
            }
        }

        public override async Task<StudentEntity> GetByIdAsync(Int64 id)
        {
            using (this.Database)
            {
                return await this.Database.Students.FindAsync(id);
            }
        }
    }
}
