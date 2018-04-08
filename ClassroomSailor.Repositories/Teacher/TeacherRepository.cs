using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.DAL.DatabaseContext;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Repositories.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.Teacher
{
    public class TeacherRepository : IClassroomSailorUserRepository<TeacherEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public TeacherRepository(ClassroomSailorDbContext dbContext)
        {
            this._database = dbContext;
        }

        public async Task<TeacherEntity> GetByIdAsync(Int64 teacherId)
        {
            using (this._database)
            {
                return await this._database.Teachers.FindAsync(teacherId);
            }
        }

        public async Task<TeacherEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                return await Task.FromResult<TeacherEntity>(this._database.Teachers.FirstOrDefault(teacher =>
                    String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
            }
        }

        public async Task<IEnumerable<TeacherEntity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Teachers);
            }
        }

        public async Task<TeacherEntity> AddAsync(TeacherEntity entity)
        {
            using (this._database)
            {
                if (entity == null)
                {
                    return null;
                }

                EntityEntry<TeacherEntity> entry = await this._database.AddAsync(entity);
                return entry.Entity;
            }
        }
    }
}
