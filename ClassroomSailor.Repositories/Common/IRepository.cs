using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Repositories.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Int64 id);

        Task<IEnumerable<T>> GetAll();
    }
}
