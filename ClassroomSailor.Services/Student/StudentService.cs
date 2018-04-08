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

        public async Task<IEnumerable<StudentEntity>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        public async Task<StudentEntity> GetByEmailAsync(String email)
        {
            return await this._repository.GetByEmailAsync(email);
        }

        public async Task<StudentEntity> GetByIdAsync(Int64 id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<StudentEntity> AddAsync(StudentEntity entity)
        {
            return await this._repository.AddAsync(entity);
        }

        public async Task<StudentEntity> UpdateAsync(StudentEntity entity)
        {
            return await this._repository.UpdateAsync(entity);
        }

        public async Task<StudentEntity> DeleteAsync(StudentEntity entity)
        {
            return await this._repository.DeleteAsync(entity);
        }
    }
}
