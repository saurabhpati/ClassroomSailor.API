using System;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.Common;

namespace ClassroomSailor.Services.User
{
    public interface IClassroomSailorUserService<T> : IService<T> where T : ClassroomSailorUserEntity
    {
        Task<T> GetByEmailAsync(String email);
    }
}
