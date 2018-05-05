using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Services.Common
{
    public interface IService<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(String id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T model);

        Task<T> UpdateAsync(T model);

        Task<T> DeleteAsync(String id);
    }
}
