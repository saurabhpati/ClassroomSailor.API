using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomSailor.Entities.Subject;
using ClassroomSailor.Entities.User;
using ClassroomSailor.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ClassroomSailor.Repositories.Test.Teacher
{
    public class TeacherRepositoryTest
    {
        private Mock<ClassroomSailorDbContext> _dbContext;
        private Mock<DbSet<TeacherEntity>> _mockTeacherSet;
        private IQueryable<TeacherEntity> _teachers;
        private readonly IClassroomSailorUserRepository<TeacherEntity> _teacherRepository;

        public TeacherRepositoryTest()
        {
            this._dbContext = new Mock<ClassroomSailorDbContext>();
            this._mockTeacherSet = new Mock<DbSet<TeacherEntity>>();
            this._teachers = new List<TeacherEntity>()
            {
                new TeacherEntity()
                {
                    Id = 1,
                    FirstName = "FirstName1",
                    MiddleName = "MiddleName1",
                    LastName = "LastName1",
                    Email = "lastname1.firstname1@school.com",
                    BirthDate = new DateTime(1980, 1, 12, 10, 10, 0, 0, DateTimeKind.Local),
                    JoiningDate = new DateTime(2018, 4, 8, 8, 0, 0, 0, DateTimeKind.Local),
                    ContactNumber = "0140-5879-2456",
                    Subjects = new List<SubjectEntity>()
                    {
                        new SubjectEntity() { Id = 1, Name = "Algebra"},
                        new SubjectEntity() { Id = 2, Name = "Biology"},
                    }
                },
                new TeacherEntity()
                {
                    Id = 2,
                    FirstName = "FirstName2",
                    MiddleName = "MiddleName2",
                    LastName = "LastName2",
                    Email = "lastname2.firstname2@school.com",
                    BirthDate = new DateTime(1988, 11, 21, 23, 0, 0, 0, DateTimeKind.Local),
                    JoiningDate = new DateTime(2017, 9, 18, 8, 30, 0, 0, DateTimeKind.Local),
                    ContactNumber = "0120-2332-4774",
                    Subjects = new List<SubjectEntity>()
                    {
                        new SubjectEntity() { Id = 1, Name = "Algebra"},
                        new SubjectEntity() { Id = 2, Name = "Biology"},
                    }
                }
            }.AsQueryable();
            this._mockTeacherSet.As<IQueryable<TeacherEntity>>().Setup(m => m.Provider).Returns(this._teachers.Provider);
            this._mockTeacherSet.As<IQueryable<TeacherEntity>>().Setup(m => m.Expression).Returns(this._teachers.Expression);
            this._mockTeacherSet.As<IQueryable<TeacherEntity>>().Setup(m => m.ElementType).Returns(this._teachers.ElementType);
            this._mockTeacherSet.As<IQueryable<TeacherEntity>>().Setup(m => m.GetEnumerator()).Returns(this._teachers.GetEnumerator());
            this._teacherRepository = new TeacherRepository(this._dbContext.Object);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetTeacherTest(Int64 id)
        {
            this._dbContext.Setup(x => x.Teachers).Returns(this._mockTeacherSet.Object);
            List<TeacherEntity> entities = (await this._teacherRepository.GetAllAsync().ConfigureAwait(false)).ToList();

            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
            Assert.True(entities.Count == 2);
        }
    }
}
