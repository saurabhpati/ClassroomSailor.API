using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.DAL.DatabaseContext;
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
                return await this._database.Students.FindAsync(id);
            }
        }
        
        public async Task<StudentEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Students
                    .FirstOrDefault(student => String.Compare(student.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
            }
        }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Students);
            }
        }

        public async Task<StudentEntity> AddAsync(StudentEntity entity)
        {
            using (this._database)
            {
                EntityEntry<StudentEntity> addedEntry = await this._database.AddAsync(entity);
                return addedEntry.Entity;
            }
        }
    }
}
