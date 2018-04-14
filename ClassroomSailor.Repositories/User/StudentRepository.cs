using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Repositories.User
{
    public class StudentRepository<T> : ClassroomSailorUserRepository<T> where T : StudentEntity
    {
        public StudentRepository(ClassroomSailorDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Students as IQueryable<T>);
            }
        }

        public override async Task<T> GetByEmailAsync(String email)
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Students.FirstOrDefault(student => String.Compare(student.Email, email, StringComparison.OrdinalIgnoreCase) == 0) as T);
            }
        }

        public override async Task<T> GetByIdAsync(Int64 id)
        {
            using (this.Database)
            {
                return await this.Database.Students.FindAsync(id) as T;
            }
        }
    }
}
