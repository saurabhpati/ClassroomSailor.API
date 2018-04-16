using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Factories;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Repositories.User
{
    public class TeacherRepository : ClassroomSailorUserRepository<TeacherEntity>
    {
        private readonly ITeacherEntityFactory<TeacherEntity> _entityFactory;
        //private Action<TeacherEntity, T> converter = (teacherEntity, createdEntity) =>
        //{
        //    createdEntity.Id = teacherEntity.Id;
        //    createdEntity.Email = teacherEntity.Email;
        //    createdEntity.FirstName = teacherEntity.FirstName;
        //    createdEntity.MiddleName = teacherEntity.MiddleName;
        //    createdEntity.LastName = teacherEntity.LastName;
        //    createdEntity.Subjects = teacherEntity.Subjects;
        //    createdEntity.BirthDate = teacherEntity.BirthDate;
        //    createdEntity.ContactNumber = teacherEntity.ContactNumber;
        //    createdEntity.JoiningDate = teacherEntity.JoiningDate;
        //};

        public TeacherRepository(ClassroomSailorDbContext context, ITeacherEntityFactory<TeacherEntity> entityFactory) : base(context)
        {
            this._entityFactory = entityFactory;
        }

        public override async Task<IEnumerable<TeacherEntity>> GetAllAsync()
        {
            using (this.Database)
            {
                return await Task.FromResult(this.Database.Teachers as IQueryable<TeacherEntity>);
            }
        }

        public override async Task<TeacherEntity> GetByEmailAsync(String email)
        {
            using (this.Database)
            {
                return await Task.FromResult(
                    this.Database.Teachers
                    .FirstOrDefault(teacher => String.Compare(teacher.Email, email, StringComparison.OrdinalIgnoreCase) == 0));
            }
        }

        public async override Task<TeacherEntity> GetByIdAsync(Int64 id)
        {
            using (this.Database)
            {
                return await this.Database.Teachers.FindAsync(id);
            }
        }
    }
}
