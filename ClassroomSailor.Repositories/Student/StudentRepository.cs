using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.DAL.DatabaseContext;
using ClassroomSailor.Entities.Student;
using ClassroomSailor.Repositories.User;

namespace ClassroomSailor.Repositories.Student
{
    public class StudentRepository : IClassroomSailorUserRepository<StudentEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public StudentRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<StudentEntity> GetById(Int64 id)
        {
            return await this._database.Students.FindAsync(id);
        }
        
        public async Task<StudentEntity> GetByEmail(String email)
        {
            return await Task.FromResult(this._database.Students
                .FirstOrDefault(student => String.Compare(student.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
        }

        public async Task<IEnumerable<StudentEntity>> GetAll()
        {
            return await Task.FromResult(this._database.Students);
        }
    }
}
