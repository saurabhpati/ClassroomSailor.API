using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Repositories.User
{
    public class TeacherRepository<T> : ClassroomSailorUserRepository<T> where T : TeacherEntity
    {
        private readonly ITeacherEntityFactory<T> _entityFactory;
        private Action<TeacherEntity, T> converter = (teacherEntity, createdEntity) =>
        {
            createdEntity.Id = teacherEntity.Id;
            createdEntity.Email = teacherEntity.Email;
            createdEntity.FirstName = teacherEntity.FirstName;
            createdEntity.MiddleName = teacherEntity.MiddleName;
            createdEntity.LastName = teacherEntity.LastName;
            createdEntity.Subjects = teacherEntity.Subjects;
            createdEntity.BirthDate = teacherEntity.BirthDate;
            createdEntity.ContactNumber = teacherEntity.ContactNumber;
            createdEntity.JoiningDate = teacherEntity.JoiningDate;
        };

        public TeacherRepository(ClassroomSailorDbContext context, ITeacherEntityFactory<T> entityFactory) : base(context)
        {
            this._entityFactory = entityFactory;
        }

        public override async Task<IEnumerable<T>> GetAllAsync()
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Teachers as IQueryable<T>);
            }
        }

        public override async Task<T> GetByEmailAsync(String email)
        {
            using (this.Database)
            {
                return await Task.FromResult(
                    this.Database.Teachers
                    .FirstOrDefault(teacher => String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0)) as T;
            }
        }

        public async override Task<T> GetByIdAsync(Int64 id)
        {
            using (this.Database)
            {
                TeacherEntity entity = await this.Database.Teachers.FindAsync(id);
                T createdEntity = this._entityFactory.GetTeacher() as T;
                converter(entity, createdEntity);
                return createdEntity;
            }
        }
    }
}
