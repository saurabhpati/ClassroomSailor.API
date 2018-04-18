using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Factories
{
    public class StudentEntityFactory<T> : IStudentEntityFactory<T> where T : StudentEntity, new()
    {
        public T GetEntity()
        {
            return new T();
        }

        public StudentEntity GetStudentModel()
        {
            return new T();
        }

        public StudentEntity GetStudentEntity()
        {
            return new StudentEntity();
        }
    }
}
