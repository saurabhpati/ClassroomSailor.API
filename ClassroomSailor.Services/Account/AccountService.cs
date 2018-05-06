using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace ClassroomSailor.Services.Account
{
    public class AccountService<T> : IAccountService<T> where T : ClassroomSailorUserEntity
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

        public async Task<T> GetByIdAsync(String id)
        {
            using (this._userManager)
            {
                return this.BackwardConverter(await this._userManager.FindByIdAsync(id).ConfigureAwait(false));
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (this._userManager)
            {
                return await Task.FromResult(this._userManager.Users.Select(user => this.BackwardConverter(user))).ConfigureAwait(false);
            }
        }

        public async Task<T> GetByEmailAsync(String email)
        {
            using (this._userManager)
            {
                return this.BackwardConverter(await this._userManager.FindByEmailAsync(email).ConfigureAwait(false));
            }
        }

        public async Task<T> RegisterAsync(T model, String password, String role)
        {
            ClassroomSailorUserEntity entity = this.ForwardConverter(model);

            using (this._userManager)
            {
                IdentityResult result = await this._userManager.CreateAsync(entity, password).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    using (this._roleManager)
                    {
                        if (!await this._roleManager.RoleExistsAsync(role))
                        {
                            await this._roleManager.CreateAsync(new IdentityRole(role)).ConfigureAwait(false);
                        }
                    }

                    await this._userManager.AddToRoleAsync(entity, role).ConfigureAwait(false);
                    return this.BackwardConverter(await this._userManager.FindByEmailAsync(model.Email).ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<T> UpdateAsync(T model)
        {
            using (this._userManager)
            {
                await this._userManager.UpdateAsync(this.ForwardConverter(model)).ConfigureAwait(false);
                return this.BackwardConverter(await this._userManager.FindByEmailAsync(model.Email).ConfigureAwait(false));
            }
        }

        public async Task<T> DeleteAsync(String id)
        {
            using (this._userManager)
            {
                return this.BackwardConverter(await this._userManager.FindByIdAsync(id).ConfigureAwait(false));
            }
        }

        public Task<T> AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        private ClassroomSailorUserEntity ForwardConverter(T model)
        {
            ClassroomSailorUserEntity entity = this._factory.GetUserEntity();
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.MiddleName = model.MiddleName;
            entity.LastName = model.LastName;
            entity.PasswordHash = model.PasswordHash;
            entity.BirthDate = model.BirthDate;
            entity.Email = model.Email;
            entity.UserName = model.UserName;
            entity.PhoneNumber = model.PhoneNumber;
            entity.AccessFailedCount = model.AccessFailedCount;
            entity.ConcurrencyStamp = model.ConcurrencyStamp;
            entity.EmailConfirmed = model.EmailConfirmed;
            entity.LockoutEnabled = model.LockoutEnabled;
            entity.LockoutEnd = model.LockoutEnd;
            entity.NormalizedEmail = model.NormalizedEmail;
            entity.NormalizedUserName = model.NormalizedUserName;
            entity.PasswordHash = model.PasswordHash;
            entity.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
            entity.SecurityStamp = model.SecurityStamp;
            entity.TwoFactorEnabled = model.TwoFactorEnabled;
            return entity;
        }

        private T BackwardConverter(ClassroomSailorUserEntity entity)
        {
            T model = this._factory.GetUserEntity() as T;
            model.Id = entity.Id;
            model.FirstName = entity.FirstName;
            model.MiddleName = entity.MiddleName;
            model.LastName = entity.LastName;
            model.PasswordHash = entity.PasswordHash;
            model.BirthDate = entity.BirthDate;
            model.Email = entity.Email;
            model.UserName = entity.UserName;
            model.PhoneNumber = entity.PhoneNumber;
            model.AccessFailedCount = entity.AccessFailedCount;
            model.ConcurrencyStamp = entity.ConcurrencyStamp;
            model.EmailConfirmed = entity.EmailConfirmed;
            model.LockoutEnabled = entity.LockoutEnabled;
            model.LockoutEnd = entity.LockoutEnd;
            model.NormalizedEmail = entity.NormalizedEmail;
            model.NormalizedUserName = entity.NormalizedUserName;
            model.PasswordHash = entity.PasswordHash;
            model.PhoneNumberConfirmed = entity.PhoneNumberConfirmed;
            model.SecurityStamp = entity.SecurityStamp;
            model.TwoFactorEnabled = entity.TwoFactorEnabled;
            return model;
        }
    }
}
