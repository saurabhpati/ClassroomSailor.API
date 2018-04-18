﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Repositories.Common
{
    public interface IRepository<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(Int64 id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(Int64 id);
    }
}
