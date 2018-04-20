using ClassroomSailor.Entities.Subject;

namespace ClassroomSailor.Entities.Factories
{
    public class SubjectEntityFactory<T> : ISubjectEntityFactory<T> where T : SubjectEntity, new()
    {
        public T GetEntity()
        {
            return new T();
        }

        public SubjectEntity GetSubjectEntity()
        {
            return new SubjectEntity();
        }

        public SubjectEntity GetSubjectModel()
        {
            return new T();
        }
    }
}
