using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.User
{
    public class TeacherRepository : IClassroomSailorUserRepository<TeacherEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public TeacherRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<IEnumerable<TeacherEntity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Teachers as IQueryable<TeacherEntity>).ConfigureAwait(false);
            }
        }

        public async Task<TeacherEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                return await Task.FromResult(
                    this._database.Teachers
                    .FirstOrDefault(teacher => String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0)).ConfigureAwait(false);
            }
        }

        public async Task<TeacherEntity> GetByIdAsync(Int64 id)
        {
            using (this._database)
            {
                return await this._database.Teachers.FindAsync(id).ConfigureAwait(false);
            }
        }

        public async Task<TeacherEntity> AddAsync(TeacherEntity entity)
        {
            using (this._database)
            {
                EntityEntry<TeacherEntity> addedEntry = await this._database.AddAsync(entity).ConfigureAwait(false);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return addedEntry.Entity;
            }
        }

        public async Task<TeacherEntity> DeleteAsync(Int64 id)
        {
            using (this._database)
            {
                TeacherEntity deleteEntity = await this._database.FindAsync<TeacherEntity>(id).ConfigureAwait(false);
                EntityEntry<TeacherEntity> entry = this._database.Remove<TeacherEntity>(deleteEntity);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity;
            }
        }

        public async Task<TeacherEntity> UpdateAsync(TeacherEntity entity)
        {
            using (this._database)
            {
                EntityEntry<TeacherEntity> entry = this._database.Update<TeacherEntity>(entity);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity;
            }
        }
    }
}
