using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Factories
{
    public class StudentEntityFactory<T> : IStudentEntityFactory<T> where T : StudentEntity, new()
    {
        public T GetEntity()
        {
            return new T();
        }

        public StudentEntity GetStudent()
        {
            return new T();
        }
    }
}
