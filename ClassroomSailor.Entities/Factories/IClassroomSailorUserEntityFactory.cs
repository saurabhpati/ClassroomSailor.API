using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Factories
{
    public interface IClassroomSailorUserEntityFactory<T> : IEntityFactory<T> where T : IClassroomSailorUserEntity
    {
        ClassroomSailorUserEntity GetUserEntity();
    }
}
