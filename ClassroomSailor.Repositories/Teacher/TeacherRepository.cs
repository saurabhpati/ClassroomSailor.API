using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.DAL.DatabaseContext;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Repositories.User;

namespace ClassroomSailor.Repositories.Teacher
{
    public class TeacherRepository : IClassroomSailorUserRepository<TeacherEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public TeacherRepository(ClassroomSailorDbContext dbContext)
        {
            this._database = dbContext;
        }

        public async Task<TeacherEntity> GetById(Int64 teacherId)
        {
            return await this._database.Teachers.FindAsync(teacherId);
        }

        public async Task<TeacherEntity> GetByEmail(String email)
        {
            return await Task.FromResult<TeacherEntity>(this._database.Teachers.FirstOrDefault(teacher =>
                String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
        }

        public async Task<IEnumerable<TeacherEntity>> GetAll()
        {
            return await Task.FromResult(this._database.Teachers);
        }
    }
}
