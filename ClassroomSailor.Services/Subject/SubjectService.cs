using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Repositories.Common;
using ClassroomSailor.Services.Common;

namespace ClassroomSailor.Services.Subject
{
    public class SubjectService<T> : IService<T> where T : SubjectEntity
    {
        private readonly IRepository<SubjectEntity> _repository;

        public SubjectService(IRepository<SubjectEntity> repository)
        {
            this._repository = repository;
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

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
