using System;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.Common;

namespace ClassroomSailor.Services.Account
{
    public interface IAccountService<T> : IService<T> where T : IClassroomSailorUserEntity
    {
        Task<T> RegisterAsync(T model, String password, String role);

        Task<T> GetByEmailAsync(String email);
    }
}
