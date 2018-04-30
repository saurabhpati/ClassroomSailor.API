using System;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Common;
using ClassroomSailor.Repositories.Common;

namespace ClassroomSailor.Repositories.Classroom
{
    public interface IClassroomRepository<T> : IRepository<T> where T : IBaseEntity
    {
        Task<IQueryable<T>> GetClassroomsByGrade(Int16 grade);
    }
}
