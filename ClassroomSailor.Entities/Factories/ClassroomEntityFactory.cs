using ClassroomSailor.Entities.Classroom;

namespace ClassroomSailor.Entities.Factories
{
    public class ClassroomEntityFactory<T> : IClassroomEntityFactory<T> where T : ClassroomEnity, new()
    {
        public T GetEntity()
        {
            return new T();
        }

        public ClassroomEnity GetModel()
        {
            return new T();
        }
    }
}
