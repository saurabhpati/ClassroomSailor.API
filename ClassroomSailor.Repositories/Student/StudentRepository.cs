using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Student;
using ClassroomSailor.Repositories.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.Student
{
    public class StudentRepository : IClassroomSailorUserRepository<StudentEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public StudentRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<StudentEntity> GetByIdAsync(Int64 id)
        {
            using (this._database)
            {
                StudentEntity entity = await this._database.Students.FindAsync(id);
                await this._database.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<StudentEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {

                StudentEntity entity = this._database.Students
                    .FirstOrDefault(student => String.Compare(student.Email, email, StringComparison.OrdinalIgnoreCase) == 0);
                await this._database.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            using (this._database)
            {
                IEnumerable<StudentEntity> students = this._database.Students;
                await this._database.SaveChangesAsync();
                return students;
            }
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

        public async Task<StudentEntity> UpdateAsync(StudentEntity entity)
        {
            using (this._database)
            {
                EntityEntry<StudentEntity> entry = this._database.Update<StudentEntity>(entity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<StudentEntity> DeleteAsync(StudentEntity entity)
        {
            using (this._database)
            {
                EntityEntry<StudentEntity> entry = this._database.Remove<StudentEntity>(entity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }
    }
}
