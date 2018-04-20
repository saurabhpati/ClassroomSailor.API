using ClassroomSailor.Entities.Subject;

namespace ClassroomSailor.Entities.Factories
{
    public interface ISubjectEntityFactory<T> : IEntityFactory<T> where T : SubjectEntity
    {
        SubjectEntity GetSubjectEntity();

        SubjectEntity GetSubjectModel();
    }
}
