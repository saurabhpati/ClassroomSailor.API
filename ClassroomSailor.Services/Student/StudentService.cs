using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Student;
using ClassroomSailor.Repositories.User;
using ClassroomSailor.Services.User;

namespace ClassroomSailor.Services.Student
{
    public class StudentService : IClassroomSailorUserService<StudentEntity>
    {
        private readonly IClassroomSailorUserRepository<StudentEntity> _repository;

        public StudentService(IClassroomSailorUserRepository<StudentEntity> repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<StudentEntity>> GetAll()
        {
            return await this._repository.GetAll();
        }

        public async Task<StudentEntity> GetByEmail(String email)
        {
            return await this._repository.GetByEmail(email);
        }

        public async Task<StudentEntity> GetById(Int64 id)
        {
            return await this._repository.GetById(id);
        }
    }
}
