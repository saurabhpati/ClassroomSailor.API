using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.User
{
    public class ClassroomSailorUserRepository<T> : IClassroomSailorUserRepository<T> where T : ClassroomSailorUserEntity
    {
        private readonly ClassroomSailorDbContext _database;

        public ClassroomSailorUserRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            using (this._database)
            {
                EntityEntry<T> addedEntry = await _database.AddAsync(entity);
                await this._database.SaveChangesAsync();
                return addedEntry.Entity;
            }
        }

        public async Task<T> DeleteAsync(Int64 id)
        {
            using (this._database)
            {
                T deleteEntity = await this._database.FindAsync<T>(id);
                EntityEntry<T> entry = this._database.Remove<T>(deleteEntity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (this._database)
            {
                IQueryable<T> entities = typeof(T) == typeof(TeacherEntity) ? this._database.Teachers as IQueryable<T> : this._database.Students as IQueryable<T>;
                await this._database.SaveChangesAsync();
                return entities;
            };
        }

        public async Task<T> GetByEmailAsync(String email)
        {
            using (this._database)
            {
                T entity = null;
                if (typeof(T) == typeof(TeacherEntity))
                {
                    entity = this._database.Teachers.FirstOrDefault(teacher =>
                    String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0) as T;
                }
                else
                {
                    entity = this._database.Students.FirstOrDefault(teacher =>
                    String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0) as T;
                }
                return await Task.FromResult<T>(entity);
            }
        }

        public async Task<T> GetByIdAsync(Int64 id)
        {
            using (this._database)
            {
                T entity = null;

                if (typeof(T) == typeof(TeacherEntity))
                {
                    entity = await this._database.Teachers.FindAsync(id) as T;
                }
                else
                {
                    entity = await this._database.Students.FindAsync(id) as T;
                }

                return entity;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using (this._database)
            {
                EntityEntry<T> entry = this._database.Update<T>(entity);
                await this._database.SaveChangesAsync();
                return entry.Entity;
            }
        }
    }
}
