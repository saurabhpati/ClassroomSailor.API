using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Services.Common
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> GetById(Int64 id);

        Task<IEnumerable<T>> GetAll();
    }
}
