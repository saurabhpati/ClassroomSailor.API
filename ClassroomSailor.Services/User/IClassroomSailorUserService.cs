using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.Common;

namespace ClassroomSailor.Services.User
{
    public interface IClassroomSailorUserService<T> : IService<T> where T : IClassroomSailorUserEntity
    {
        Task<T> GetByIdAsync(Int64 id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByEmailAsync(String email);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(Int64 id);
    }
}
