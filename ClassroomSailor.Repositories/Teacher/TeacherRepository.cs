using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.DAL.DatabaseContext;
using ClassroomSailor.Entities.Teacher;

namespace ClassroomSailor.Repositories.Teacher
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ClassroomSailorDbContext _database;

        public TeacherRepository(ClassroomSailorDbContext dbContext)
        {
            this._database = dbContext;
        }

        public async Task<TeacherEntity> GetTeacherById(Int64 teacherId)
        {
            return await this._database.Teachers.FindAsync(teacherId);
        }

        public async Task<TeacherEntity> GetTeacherByEmail(String email)
        {
            return await Task.FromResult<TeacherEntity>(this._database.Teachers.FirstOrDefault(teacher =>
                String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
        }

        public async Task<IEnumerable<TeacherEntity>> GetAllTeachers()
        {
            return await Task.FromResult<IQueryable<TeacherEntity>>(this._database.Teachers);
        }
    }
}
