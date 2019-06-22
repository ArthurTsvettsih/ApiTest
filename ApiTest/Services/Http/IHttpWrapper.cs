using System.Threading.Tasks;

namespace Services.Http
{
    public interface IHttpWrapper<T>
    {
        Task<T> MakeHttpCall(string url);
    }
}
