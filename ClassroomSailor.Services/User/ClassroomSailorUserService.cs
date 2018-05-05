using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories.User;

namespace ClassroomSailor.Services.User
{
    public class ClassroomSailorUserService<T> : IClassroomSailorUserService<T> where T : ClassroomSailorUserEntity
    {
        private readonly IClassroomSailorUserRepository<ClassroomSailorUserEntity> _repository;
        private readonly IClassroomSailorUserEntityFactory<T> _factory;

        public ClassroomSailorUserService(
            IClassroomSailorUserRepository<ClassroomSailorUserEntity> repository,
            IClassroomSailorUserEntityFactory<T> factory)
        {
            this._repository = repository;
            this._factory = factory;
        }

        public async Task<T> AddAsync(T model)
        {
            return this.BackwardConverter(await this._repository.AddAsync(this.ForwardConverter(model)));
        }

        public async Task<T> DeleteAsync(String id)
        {
            return this.BackwardConverter(await this._repository.DeleteAsync(id).ConfigureAwait(false));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<ClassroomSailorUserEntity> entities = (await this._repository.GetAllAsync().ConfigureAwait(false)).ToList();
            List<T> models = new List<T>();
            entities.ForEach(entity => models.Add(this.BackwardConverter(entity)));
            return models;
        }

        public async Task<T> GetByEmailAsync(String email)
        {
            return this.BackwardConverter(await this._repository.GetByEmailAsync(email).ConfigureAwait(false));
        }

        public async Task<T> GetByIdAsync(String id)
        {
            return this.BackwardConverter(await this._repository.GetByIdAsync(id).ConfigureAwait(false));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return this.BackwardConverter(await this._repository.UpdateAsync(this.ForwardConverter(entity)).ConfigureAwait(false));
        }

        private ClassroomSailorUserEntity ForwardConverter(T model)
        {
            ClassroomSailorUserEntity entity = this._factory.GetUserEntity();
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.MiddleName = model.MiddleName;
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
            T model = this._factory.GetEntity();
            model.Id = entity.Id;
            model.FirstName = entity.FirstName;
            model.MiddleName = entity.MiddleName;
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
