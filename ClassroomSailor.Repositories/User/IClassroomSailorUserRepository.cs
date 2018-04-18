using System;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories.Common;

namespace ClassroomSailor.Repositories.User
{
    public interface IClassroomSailorUserRepository<T> : IRepository<T> where T : IClassroomSailorUserEntity
    {
        Task<T> GetByEmailAsync(String email);
    }
}
