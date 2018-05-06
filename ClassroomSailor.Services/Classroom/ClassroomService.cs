using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Classroom;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Repositories.Classroom;

namespace ClassroomSailor.Services.Classroom
{
    public class ClassroomService<T> : IClassroomService<T> where T : ClassroomEnity
    {
        private readonly IClassroomRepository<ClassroomEnity> _repository;
        private readonly IClassroomEntityFactory<T> _factory;

        public ClassroomService(IClassroomRepository<ClassroomEnity> repository, IClassroomEntityFactory<T> factory)
        {
            this._repository = repository;
            this._factory = factory;
        }

        public async Task<T> AddAsync(T model)
        {
            return this.BackwardConverter(await this._repository.AddAsync(this.ForwardConverter(model)).ConfigureAwait(false));
        }

        public async Task<T> DeleteAsync(Int32 id)
        {
            return this.BackwardConverter(await this._repository.DeleteAsync(id).ConfigureAwait(false));
        }

        public Task<T> DeleteAsync(String id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await this._repository.GetAllAsync().ConfigureAwait(false)).Select(room => this.BackwardConverter(room));
        }

        public async Task<T> GetByIdAsync(Int32 id)
        {
            return this.BackwardConverter(await this._repository.GetByIdAsync(id).ConfigureAwait(false));
        }

        public Task<T> GetByIdAsync(String id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T model)
        {
            return this.BackwardConverter(await this._repository.UpdateAsync(this.ForwardConverter(model)).ConfigureAwait(false));
        }

        public async Task<IEnumerable<T>> GetClassroomsByGrade(Int16 grade)
        {
            return (await this._repository.GetClassroomsByGrade(grade).ConfigureAwait(false)).Select(room => this.BackwardConverter(room));
        }

        private ClassroomEnity ForwardConverter(T model)
        {
            ClassroomEnity entity = this._factory.GetModel();
            entity.Id = model.Id;
            entity.Grade = model.Grade;
            entity.Section = model.Section;
            entity.Subjects = model.Subjects;
            entity.Users = model.Users;
            return entity;
        }

        private T BackwardConverter(ClassroomEnity entity)
        {
            T model = this._factory.GetEntity();
            model.Id = entity.Id;
            model.Grade = entity.Grade;
            model.Section = entity.Section;
            model.Subjects = entity.Subjects;
            model.Users = entity.Users;
            return model;
        }
    }
}
