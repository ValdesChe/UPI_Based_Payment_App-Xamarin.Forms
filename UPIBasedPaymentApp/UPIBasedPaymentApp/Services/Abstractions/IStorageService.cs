using System.Threading.Tasks;

namespace UPIBasedPaymentApp.Services.Abstractions
{
    public interface IStorageService
    {
        Task<T> GetAsync<T>(string key, T defaultValue = default(T));
        Task SaveAsync<T>(string key, T obj);
        Task RemoveAsync(string key);
    }
}
