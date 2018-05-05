using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.User
{
    public class ClassroomSailorUserRepository : IClassroomSailorUserRepository<ClassroomSailorUserEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public ClassroomSailorUserRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<ClassroomSailorUserEntity> AddAsync(ClassroomSailorUserEntity entity)
        {
            using (this._database)
            {
                EntityEntry<ClassroomSailorUserEntity> entry = await this._database.AddAsync<ClassroomSailorUserEntity>(entity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<ClassroomSailorUserEntity> DeleteAsync(String id)
        {
            using (this._database)
            {
                ClassroomSailorUserEntity entity = await this._database.Users.FindAsync(id).ConfigureAwait(false);
                EntityEntry<ClassroomSailorUserEntity> entry = this._database.Users.Remove(entity);
                return entry.Entity;
            }
        }

        public async Task<IEnumerable<ClassroomSailorUserEntity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Users.AsQueryable());
            }
        }

        public async Task<ClassroomSailorUserEntity> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                return await Task.FromResult(
                    this._database
                        .Users
                        .FirstOrDefault(user => String.Compare(user.Email, email, StringComparison.OrdinalIgnoreCase) == 0))
                        .ConfigureAwait(false);
            }
        }

        public async Task<ClassroomSailorUserEntity> GetByIdAsync(String id)
        {
            using (this._database)
            {
                return await this._database.Users.FindAsync(id).ConfigureAwait(false);
            }
        }

        public async Task<ClassroomSailorUserEntity> UpdateAsync(ClassroomSailorUserEntity entity)
        {
            using (this._database)
            {
                EntityEntry<ClassroomSailorUserEntity> entry = this._database.Update(entity);
                return await Task.FromResult(entry.Entity).ConfigureAwait(false);
            }
        }
    }
}
