using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Repositories.Common
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(String id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(String id);
    }
}
