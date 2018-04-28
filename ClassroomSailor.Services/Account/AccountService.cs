using System;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace ClassroomSailor.Services.Account
{
    public class AccountService : IAccountService<ClassroomSailorUserEntity>
    {
        private readonly UserManager<ClassroomSailorUserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IClassroomSailorUserEntityFactory<ClassroomSailorUserEntity> _factory;

        public AccountService(
            UserManager<ClassroomSailorUserEntity> userManager, 
            RoleManager<IdentityRole> roleManager,
            IClassroomSailorUserEntityFactory<ClassroomSailorUserEntity> factory)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._factory = factory;
        }

        public async Task<IdentityResult> RegisterAsync(string role, string username, string password, string firstName, string lastName, string email, DateTime birthDate, string middleName = null, string phoneNumber = null)
        {
            ClassroomSailorUserEntity entity = this._factory.GetEntity();
            entity.UserName = username;
            entity.FirstName = firstName;
            entity.MiddleName = middleName;
            entity.LastName = lastName;
            entity.Email = email;
            entity.BirthDate = birthDate;
            IdentityResult result = await this._userManager.CreateAsync(entity, password).ConfigureAwait(false);

            if (!await this._roleManager.RoleExistsAsync(role))
            {
                await this._roleManager.CreateAsync(new IdentityRole(role)).ConfigureAwait(false);
            }

            await this._userManager.AddToRoleAsync(entity, role).ConfigureAwait(false);
            return result;
        }
    }
}
