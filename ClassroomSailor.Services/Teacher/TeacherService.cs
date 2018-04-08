using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Repositories.User;
using ClassroomSailor.Services.User;

namespace ClassroomSailor.Services.Teacher
{
    public class TeacherService : IClassroomSailorUserService<TeacherEntity>
    {
        private readonly IClassroomSailorUserRepository<TeacherEntity> _repository;

        public TeacherService(IClassroomSailorUserRepository<TeacherEntity> repository)
        {
            this._repository = repository;
        }

        public async Task<TeacherEntity> GetById(Int64 teacherId)
        {
            return await this._repository.GetById(teacherId);
        }

        public async Task<TeacherEntity> GetByEmail(String email)
        {
            return await this._repository.GetByEmail(email);
        }

        public async Task<IEnumerable<TeacherEntity>> GetAll()
        {
            return await this._repository.GetAll();
        }
    }
}
