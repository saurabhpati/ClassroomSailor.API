using ClassroomSailor.API.Models.User;

namespace ClassroomSailor.API.Models.Factory
{
    public class ClassroomSailorUserModelFactory<T> : IModelFactory<T> where T : ClassroomSailorUserApiModel, new()
    {
        public T GetModel()
        {
            return new T();
        }
    }
}
