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

        public TeacherService(IClassroomSailorUserRepository<TeacherEntity> repository, ITeacherEntityFactory<T> teacherFactory)
        {
            this._repository = repository;
            this._teacherFactory = teacherFactory;
        }

        public async Task<T> AddAsync(T entity)
        {
            return this.BackwardConverter(await this._repository.AddAsync(this.ForwardConverter(entity)).ConfigureAwait(false));
        }

        public async Task<T> DeleteAsync(Int64 id)
        {
            return this.BackwardConverter(await this._repository.DeleteAsync(id).ConfigureAwait(false));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<TeacherEntity> teacherEntities = (await this._repository.GetAllAsync().ConfigureAwait(false)).ToList();
            List<T> entities = new List<T>();
            teacherEntities.ForEach(entity => entities.Add(this.BackwardConverter(entity)));
            return entities;
        }

        public async Task<T> GetByEmailAsync(String email)
        {
            return this.BackwardConverter(await this._repository.GetByEmailAsync(email).ConfigureAwait(false));
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            return this.BackwardConverter(await this._repository.GetByIdAsync(id).ConfigureAwait(false));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return this.BackwardConverter(await this._repository.UpdateAsync(this.BackwardConverter(entity)).ConfigureAwait(false));
        }

        private T BackwardConverter(TeacherEntity teacherEntity)
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
        }

        private TeacherEntity ForwardConverter(T model)
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
        }
    }
}
