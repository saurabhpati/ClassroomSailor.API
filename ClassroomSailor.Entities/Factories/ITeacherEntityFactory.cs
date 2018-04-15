using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Factories
{
    public interface ITeacherEntityFactory<T> : IClassroomSailorUserEntityFactory<T> where T: TeacherEntity
    {
        TeacherEntity GetTeacher();
    }
}
