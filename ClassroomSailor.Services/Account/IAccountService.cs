using System;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Services.Common;
using Microsoft.AspNetCore.Identity;

namespace ClassroomSailor.Services.Account
{
    public interface IAccountService<T> : IService<T> where T : IClassroomSailorUserEntity
    {
        Task<IdentityResult> RegisterAsync(string role, string username, string password, string firstName, string lastName, string email, DateTime birthDate, string middleName = null, string phoneNumber = null);
    }
}
