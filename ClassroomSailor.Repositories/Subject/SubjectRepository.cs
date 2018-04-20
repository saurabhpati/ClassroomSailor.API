using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Repositories.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClassroomSailor.Repositories.Subject
{
    public class SubjectRepository : IRepository<SubjectEntity>
    {
        private readonly ClassroomSailorDbContext _database;

        public SubjectRepository(ClassroomSailorDbContext context)
        {
            this._database = context;
        }

        public async Task<SubjectEntity> AddAsync(SubjectEntity entity)
        {
            using (this._database)
            {
                EntityEntry<SubjectEntity> entry = await this._database.Subjects.AddAsync(entity).ConfigureAwait(false);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity;
            }
        }

        public async Task<SubjectEntity> DeleteAsync(long id)
        {
            using (this._database)
            {
                SubjectEntity entity = await this._database.Subjects.FindAsync(id).ConfigureAwait(false);
                EntityEntry<SubjectEntity> entry = this._database.Subjects.Remove(entity);
                await this._database.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity;
            }
        }

        public async Task<IEnumerable<SubjectEntity>> GetAllAsync()
        {
            using (this._database)
            {
                return await Task.FromResult(this._database.Subjects).ConfigureAwait(false) as IQueryable<SubjectEntity>;
            }
        }

        public async Task<SubjectEntity> GetByIdAsync(long id)
        {
            using (this._database)
            {
                return await this._database.Subjects.FindAsync(id).ConfigureAwait(false);
            }
        }

        public async Task<SubjectEntity> UpdateAsync(SubjectEntity entity)
        {
            using (this._database)
            {
                EntityEntry<SubjectEntity> entry = this._database.Update<SubjectEntity>(entity);
                return await Task.FromResult(entry.Entity).ConfigureAwait(false);
            }
        }
    }
}
