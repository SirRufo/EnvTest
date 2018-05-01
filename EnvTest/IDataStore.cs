using System.Threading.Tasks;

namespace EnvTest
{
    public interface IDataStore
    {
        Task ClearAsync();
        Task DeleteAsync<T>( string key );
        Task<T> GetAsync<T>( string key );
        Task StoreAsync<T>( string key, T value );
    }
}