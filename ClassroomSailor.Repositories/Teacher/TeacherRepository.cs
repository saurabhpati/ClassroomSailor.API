using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                TeacherEntity entity = await this._database.Teachers.FindAsync(teacherId);
                await this._database.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<TeacherEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                TeacherEntity entity = this._database.Teachers.FirstOrDefault(teacher =>
                    String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0);
                await this._database.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<TeacherEntity>> GetAllAsync()
        {
            using (this._database)
            {
                IEnumerable<TeacherEntity> teachers = this._database.Teachers;
                await this._database.SaveChangesAsync();
                return teachers;
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
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<TeacherEntity> UpdateAsync(TeacherEntity entity)
        {
            using (this._database)
            {
                EntityEntry<TeacherEntity> entry = this._database.Update<TeacherEntity>(entity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<TeacherEntity> DeleteAsync(Int64 id)
        {
            using (this._database)
            {
                TeacherEntity deleteEntity = await this._database.FindAsync<TeacherEntity>(id);
                EntityEntry<TeacherEntity> entry = this._database.Remove<TeacherEntity>(deleteEntity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }
    }
}
