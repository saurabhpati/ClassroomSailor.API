using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories.User;

namespace ClassroomSailor.Services.User
{
    public class TeacherService<T> : IClassroomSailorUserService<T> where T : TeacherEntity
    {
        private readonly IClassroomSailorUserRepository<TeacherEntity> _repository;
        private readonly ITeacherEntityFactory<T> _teacherFactory;
        private readonly Func<TeacherEntity, T> _converter;

        public TeacherService(IClassroomSailorUserRepository<TeacherEntity> repository, ITeacherEntityFactory<T> teacherFactory)
        {
            this._repository = repository;
            this._teacherFactory = teacherFactory;
            this._converter = (teacherEntity) =>
            {
                T createdEntity = this._teacherFactory.GetTeacher() as T;
                createdEntity.Id = teacherEntity.Id;
                createdEntity.Email = teacherEntity.Email;
                createdEntity.FirstName = teacherEntity.FirstName;
                createdEntity.MiddleName = teacherEntity.MiddleName;
                createdEntity.LastName = teacherEntity.LastName;
                createdEntity.Subjects = teacherEntity.Subjects;
                createdEntity.BirthDate = teacherEntity.BirthDate;
                createdEntity.ContactNumber = teacherEntity.ContactNumber;
                createdEntity.JoiningDate = teacherEntity.JoiningDate;
                return createdEntity;
            };
        }

        public async Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return this._converter(await this._repository.GetByIdAsync(id));
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
