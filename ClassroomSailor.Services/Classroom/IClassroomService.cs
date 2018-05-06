using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Classroom;
using ClassroomSailor.Services.Common;

namespace ClassroomSailor.Services.Classroom
{
    public interface IClassroomService<T> : IService<T> where T : ClassroomEnity
    {
        Task<T> GetByIdAsync(Int32 id);

        Task<T> DeleteAsync(Int32 id);

        Task<IEnumerable<T>> GetClassroomsByGrade(Int16 grade);
    }
}
