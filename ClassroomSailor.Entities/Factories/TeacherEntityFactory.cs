using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Factories
{
    public class TeacherEntityFactory<T> : ITeacherEntityFactory<T> where T : TeacherEntity, new()
    {
        public T GetEntity()
        {
            return new T();
        }

        public TeacherEntity GetTeacher()
        {
            return new T();
        }
    }
}
