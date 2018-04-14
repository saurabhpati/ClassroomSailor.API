using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Repositories.User
{
    public class TeacherRepository<T> : ClassroomSailorUserRepository<T> where T : TeacherEntity
    {
        public TeacherRepository(ClassroomSailorDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Teachers as IQueryable<T>);
            }
        }

        public override async Task<T> GetByEmailAsync(String email)
        {
            using (this.Database)
            {
                return await Task.FromResult(
                    this.Database.Teachers
                    .FirstOrDefault(teacher => String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0)) as T;
            }
        }

        public async override Task<T> GetByIdAsync(Int64 id)
        {
            using (this.Database)
            {
                TeacherEntity entity2 = await this.Database.Teachers.FindAsync(id);
                T entity = await this.Database.Teachers.FindAsync(id) as T;
                return entity;
            }
        }
    }
}
