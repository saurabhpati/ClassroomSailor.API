using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.User
{
    public class StudentRepository : IClassroomSailorUserRepository<StudentEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public StudentRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<StudentEntity> AddAsync(StudentEntity entity)
        {
            using (this._database)
            {
                EntityEntry<StudentEntity> addedEntry = await this._database.AddAsync(entity).ConfigureAwait(false);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return addedEntry.Entity;
            }
        }

        public async Task<StudentEntity> DeleteAsync(Int64 id)
        {
            using (this._database)
            {
                StudentEntity deleteEntity = await this._database.FindAsync<StudentEntity>(id).ConfigureAwait(false);
                EntityEntry<StudentEntity> entry = this._database.Remove<StudentEntity>(deleteEntity);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity;
            }
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Students as IQueryable<StudentEntity>).ConfigureAwait(false);
            }
        }

        public async Task<StudentEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Students.FirstOrDefault(student => String.Compare(student.Email, email, StringComparison.OrdinalIgnoreCase) == 0)).ConfigureAwait(false);
            }
        }

        public async Task<StudentEntity> GetByIdAsync(Int64 id)
        {
            using (this._database)
            {
                return await this._database.Students.FindAsync(id).ConfigureAwait(false);
            }
        }

        public async Task<StudentEntity> UpdateAsync(StudentEntity entity)
        {
            using (this._database)
            {
                EntityEntry<StudentEntity> entry = this._database.Update<StudentEntity>(entity);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity;
            }
        }
    }
}
