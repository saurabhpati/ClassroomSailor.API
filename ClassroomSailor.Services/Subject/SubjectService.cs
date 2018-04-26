using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Repositories.Common;
using ClassroomSailor.Services.Common;

namespace ClassroomSailor.Services.Subject
{
    public class SubjectService<T> : IService<T> where T : SubjectEntity
    {
        private readonly IRepository<SubjectEntity> _repository;
        private readonly ISubjectEntityFactory<SubjectEntity> _factory;

        public SubjectService(IRepository<SubjectEntity> repository, ISubjectEntityFactory<SubjectEntity> factory)
        {
            this._repository = repository;
            this._factory = factory;
        }

        public async Task<T> AddAsync(T entity)
        {
            SubjectEntity subject = this.ForwardConverter(entity);
            SubjectEntity addedEntity = await this._repository.AddAsync(subject).ConfigureAwait(false);
            return this.BackwardConverter(addedEntity);
        }

        public async Task<T> DeleteAsync(Int64 id)
        {
            SubjectEntity entity = await this._repository.DeleteAsync(id).ConfigureAwait(false);
            return this.BackwardConverter(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<SubjectEntity> subjects = (await this._repository.GetAllAsync().ConfigureAwait(false)).ToList();
            List<T> entities = new List<T>();
            subjects.ForEach(subject => entities.Add(this.BackwardConverter(subject)));
            return entities;
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            SubjectEntity entity = await this._repository.GetByIdAsync(id).ConfigureAwait(false);
            return this.BackwardConverter(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            SubjectEntity subject = this.ForwardConverter(entity);
            SubjectEntity updatedEntity = await this._repository.UpdateAsync(subject).ConfigureAwait(false);
            return this.BackwardConverter(updatedEntity);
        }

        private T BackwardConverter(SubjectEntity entity)
        {
            T createdEntity = this._factory.GetSubjectModel() as T;
            createdEntity.Id = entity.Id;
            createdEntity.Name = entity.Name;
            return createdEntity;
        }

        private SubjectEntity ForwardConverter(T entity)
        {
            SubjectEntity createdEntity = this._factory.GetSubjectEntity();
            createdEntity.Id = entity.Id;
            createdEntity.Name = entity.Name;
            return createdEntity;
        }
    }
}
