using System.Threading.Tasks;

namespace interaktiva14.Infrastructure
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
