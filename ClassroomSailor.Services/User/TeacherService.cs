using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly Func<TeacherEntity, T> _backwardConverter;
        private readonly Func<T, TeacherEntity> _forwardConverter;

        public TeacherService(IClassroomSailorUserRepository<TeacherEntity> repository, ITeacherEntityFactory<T> teacherFactory)
        {
            this._repository = repository;
            this._teacherFactory = teacherFactory;
            this._backwardConverter = (teacherEntity) =>
            {
                T createdEntity = this._teacherFactory.GetTeacherModel() as T;
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
            this._forwardConverter = (model) =>
            {
                TeacherEntity entity = this._teacherFactory.GetTeacherEntity();
                entity.Id = model.Id;
                entity.Email = model.Email;
                entity.FirstName = model.FirstName;
                entity.MiddleName = model.MiddleName;
                entity.LastName = model.LastName;
                entity.Subjects = model.Subjects;
                entity.BirthDate = model.BirthDate;
                entity.ContactNumber = model.ContactNumber;
                entity.JoiningDate = model.JoiningDate;
                return entity;
            };
        }

        public async Task<T> AddAsync(T entity)
        {
            return this._backwardConverter(await this._repository.AddAsync(this._forwardConverter(entity)));
        }

        public async Task<T> DeleteAsync(long id)
        {
            return this._backwardConverter(await this._repository.DeleteAsync(id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<TeacherEntity> teacherEntities = (await this._repository.GetAllAsync()).ToList();
            List<T> entities = new List<T>();
            teacherEntities.ForEach(entity => entities.Add(this._backwardConverter(entity)));
            return entities;
        }

        public async Task<T> GetByEmailAsync(string email)
        {
            return this._backwardConverter(await this._repository.GetByEmailAsync(email));
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return this._backwardConverter(await this._repository.GetByIdAsync(id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return this._backwardConverter(await this._repository.UpdateAsync(this._backwardConverter(entity)));
        }
    }
}
