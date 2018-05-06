using ClassroomSailor.Entities.Classroom;

namespace ClassroomSailor.Entities.Factories
{
    public interface IClassroomEntityFactory<T> : IEntityFactory<T> where T : ClassroomEnity
    {
        ClassroomEnity GetModel();
    }
}
