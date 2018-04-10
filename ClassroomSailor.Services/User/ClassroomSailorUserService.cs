using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;
using ClassroomSailor.Repositories.User;

namespace ClassroomSailor.Services.User
{
    public class ClassroomSailorUserService<T> : IClassroomSailorUserService<T> where T : ClassroomSailorUserEntity
    {
        private readonly IClassroomSailorUserRepository<T> _repository;

        public ClassroomSailorUserService(IClassroomSailorUserRepository<T> repository)
        {
            this._repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            return await this._repository.AddAsync(entity);
        }

        public async Task<T> DeleteAsync(Int64 id)
        {
            return await this._repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        public async Task<T> GetByEmailAsync(String email)
        {
            return await this._repository.GetByEmailAsync(email);
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await this._repository.UpdateAsync(entity);
        }
    }
}
