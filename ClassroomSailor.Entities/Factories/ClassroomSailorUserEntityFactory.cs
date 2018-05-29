using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Factories
{
    public class ClassroomSailorUserEntityFactory<T> : IClassroomSailorUserEntityFactory<T> where T : ClassroomSailorUserEntity, new()
    {
        public T GetEntity()
        {
            return new T();
        }

        public ClassroomSailorUserEntity GetUserEntity()
        {
            return new ClassroomSailorUserEntity();
        }
    }
}
