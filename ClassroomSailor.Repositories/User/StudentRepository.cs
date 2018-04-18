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
                EntityEntry<StudentEntity> addedEntry = await this._database.AddAsync(entity);
                await this._database.SaveChangesAsync();
                return addedEntry.Entity;
            }
        }

        public async Task<StudentEntity> DeleteAsync(long id)
        {
            using (this._database)
            {
                StudentEntity deleteEntity = await this._database.FindAsync<StudentEntity>(id);
                EntityEntry<StudentEntity> entry = this._database.Remove<StudentEntity>(deleteEntity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Students as IQueryable<StudentEntity>);
            }
        }

        public async Task<StudentEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Students.FirstOrDefault(student => String.Compare(student.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
            }
        }

        public async Task<StudentEntity> GetByIdAsync(Int64 id)
        {
            using (this._database)
            {
                return await this._database.Students.FindAsync(id);
            }
        }

        public async Task<StudentEntity> UpdateAsync(StudentEntity entity)
        {
            using (this._database)
            {
                EntityEntry<StudentEntity> entry = this._database.Update<StudentEntity>(entity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }
    }
}
