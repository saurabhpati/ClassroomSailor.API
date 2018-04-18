using ClassroomSailor.Entities.User;

namespace ClassroomSailor.Entities.Factories
{
    public interface IStudentEntityFactory<T> : IClassroomSailorUserEntityFactory<T> where T : StudentEntity
    {
        StudentEntity GetStudentModel();

        StudentEntity GetStudentEntity();
    }
}
