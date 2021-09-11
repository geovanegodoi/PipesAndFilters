namespace WebAPI.Infrastructure
{
    public interface IRepository
    {
        T ExecuteQuery<T>(string query) where T : class, new();
    }

    public class Repository : IRepository
    {
        public T ExecuteQuery<T>(string query) where T : class, new()
            => new T();
    }
}
