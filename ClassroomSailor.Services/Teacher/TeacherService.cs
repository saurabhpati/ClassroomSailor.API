using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Teacher;
using ClassroomSailor.Repositories.Teacher;

namespace ClassroomSailor.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            this._repository = repository;
        }

        public async Task<TeacherEntity> GetTeacherById(Int64 teacherId)
        {
            return await this._repository.GetTeacherById(teacherId);
        }

        public async Task<TeacherEntity> GetTeacherByEmail(String email)
        {
            return await this._repository.GetTeacherByEmail(email);
        }

        public async Task<IEnumerable<TeacherEntity>> GetAllTeachers()
        {
            return await this._repository.GetAllTeachers();
        }
    }
}
