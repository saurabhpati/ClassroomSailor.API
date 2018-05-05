namespace ClassroomSailor.API.Models.Factory
{
    public interface IModelFactory<T> where T : class
    {
        T GetModel();
    }
}
