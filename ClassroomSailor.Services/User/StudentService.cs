using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<T> AddAsync(T entity)
        {
            return this._converter(await this._repository.AddAsync(entity));
        }

        public async Task<T> DeleteAsync(long id)
        {
            return this._converter(await this._repository.DeleteAsync(id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<StudentEntity> students = (await this._repository.GetAllAsync()).ToList();
            List<T> entities = new List<T>();
            students.ForEach(student => entities.Add(this._converter(student)));
            return entities;
        }

        public async Task<T> GetByEmailAsync(string email)
        {
            return this._converter(await this._repository.GetByEmailAsync(email));
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return this._converter(await this._repository.GetByIdAsync(id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return this._converter(await this._repository.UpdateAsync(entity));
        }
    }
}
