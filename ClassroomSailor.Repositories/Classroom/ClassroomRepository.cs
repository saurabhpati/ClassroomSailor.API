using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Classroom;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.Classroom
{
    public class ClassroomRepository : IClassroomRepository<ClassroomEnity>
    {
        private readonly ClassroomSailorDbContext _database;

        public ClassroomRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<ClassroomEnity> AddAsync(ClassroomEnity entity)
        {
            using (this._database)
            {
                EntityEntry<ClassroomEnity> entry = await this._database.Classrooms.AddAsync(entity).ConfigureAwait(false);
                return entry.Entity;
            }
        }

        public async Task<ClassroomEnity> DeleteAsync(long id)
        {
            using (this._database)
            {
                ClassroomEnity entity = await this._database.Classrooms.FindAsync(id).ConfigureAwait(false);
                EntityEntry<ClassroomEnity> entry = this._database.Classrooms.Remove(entity);
                return entry.Entity;
            }
        }

        public async Task<IEnumerable<ClassroomEnity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Classrooms.AsQueryable());
            }
        }

        public async Task<ClassroomEnity> GetByIdAsync(long id)
        {
            using (this._database)
            {
                return await this._database.Classrooms.FindAsync(id).ConfigureAwait(false);
            }
        }

        public async Task<IQueryable<ClassroomEnity>> GetClassroomsByGrade(Int16 grade)
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Classrooms.Where(classroom => classroom.Grade == grade).AsQueryable()).ConfigureAwait(false);
            }
        }

        public async Task<ClassroomEnity> UpdateAsync(ClassroomEnity entity)
        {
            using (this._database)
            {
                EntityEntry<ClassroomEnity> entry = this._database.Classrooms.Update(entity);
                return await Task.FromResult(entry.Entity).ConfigureAwait(false);
            }
        }
    }
}
