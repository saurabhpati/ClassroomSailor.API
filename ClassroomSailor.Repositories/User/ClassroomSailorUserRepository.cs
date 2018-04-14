using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.User
{
    public abstract class ClassroomSailorUserRepository<T> : IClassroomSailorUserRepository<T> where T : ClassroomSailorUserEntity
    {
        public ClassroomSailorUserRepository(ClassroomSailorDbContext context)
        {
            this.Database = context;
        }

        protected ClassroomSailorDbContext Database { get; private set; }

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<T> GetByEmailAsync(String email);

        public abstract Task<T> GetByIdAsync(Int64 id);

        public async Task<T> AddAsync(T entity)
        {
            using (this.Database)
            {
                EntityEntry<T> addedEntry = await Database.AddAsync(entity);
                await this.Database.SaveChangesAsync();
                return addedEntry.Entity;
            }
        }

        public async Task<T> DeleteAsync(Int64 id)
        {
            using (this.Database)
            {
                T deleteEntity = await this.Database.FindAsync<T>(id);
                EntityEntry<T> entry = this.Database.Remove<T>(deleteEntity);
                await this.Database.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using (this.Database)
            {
                EntityEntry<T> entry = this.Database.Update<T>(entity);
                await this.Database.SaveChangesAsync();
                return entry.Entity;
            }
        }
    }
}
