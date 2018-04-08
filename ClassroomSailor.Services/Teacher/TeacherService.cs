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

        #region Read

        public async Task<TeacherEntity> GetByIdAsync(Int64 teacherId)
        {
            return await this._repository.GetByIdAsync(teacherId);
        }

        public async Task<TeacherEntity> GetByEmailAsync(String email)
        {
            return await this._repository.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<TeacherEntity>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        #endregion

        public async Task<TeacherEntity> AddAsync(TeacherEntity entity)
        {
            return await this._repository.AddAsync(entity);
        }

        public async Task<TeacherEntity> UpdateAsync(TeacherEntity entity)
        {
            return await this._repository.UpdateAsync(entity);
        }

        public async Task<TeacherEntity> DeleteAsync(TeacherEntity entity)
        {
            return await this._repository.DeleteAsync(entity);
        }
    }
}
