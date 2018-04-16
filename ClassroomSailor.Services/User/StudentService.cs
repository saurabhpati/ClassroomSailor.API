using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories.User;

namespace ClassroomSailor.Services.User
{
    public class StudentService<T> : IClassroomSailorUserService<T> where T : StudentEntity
    {
        private readonly IClassroomSailorUserRepository<StudentEntity> _repository;
        private readonly IStudentEntityFactory<T> _studentFactory;
        private readonly Func<StudentEntity, T> _converter;

        public StudentService(IClassroomSailorUserRepository<StudentEntity> repository, IStudentEntityFactory<T> studentFactory)
        {
            this._repository = repository;
            this._studentFactory = studentFactory;
            this._converter = (studentEntity) =>
            {
                T createdEntity = this._studentFactory.GetStudent() as T;
                createdEntity.Id = studentEntity.Id;
                createdEntity.FirstName = studentEntity.FirstName;
                createdEntity.MiddleName = studentEntity.MiddleName;
                createdEntity.LastName = studentEntity.LastName;
                createdEntity.BirthDate = studentEntity.BirthDate;
                createdEntity.AdmissionNumber = studentEntity.AdmissionNumber;
                createdEntity.AdmissionDate = studentEntity.AdmissionDate;
                createdEntity.Email = studentEntity.Email;
                createdEntity.Grade = studentEntity.Grade;
                createdEntity.Subjects = studentEntity.Subjects;
                return createdEntity;
            };
        }

        public Task<T> AddAsync(T entity)
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
