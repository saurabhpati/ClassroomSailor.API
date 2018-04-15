using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Entities.Factories
{
    public interface IEntityFactory<T> where T : IBaseEntity
    {
        T GetEntity();
    }
}
