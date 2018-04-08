using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Services.Common
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Int64 id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
