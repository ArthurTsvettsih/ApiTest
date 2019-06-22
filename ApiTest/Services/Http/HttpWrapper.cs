using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Services.Http
{
    public class HttpWrapper<T> : IHttpWrapper<T>
    {
        private readonly IMemoryCache _cache;

        public HttpWrapper(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T> MakeHttpCall(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new ArgumentException($"{nameof(url)} is an invalid Uri. {nameof(url)} - {url}");

            if (!_cache.TryGetValue(url, out T cached))
            {
                cached = await MakeHttpCallForCaching(url);

                //TODO AT: Caching time should come from settings
                _cache.Set(url, cached, TimeSpan.FromMinutes(5));
            }

            return (T)cached;
        }

        private async Task<T> MakeHttpCallForCaching(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var rawResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(rawResponse);
                }
            }

            return default;
        }
    }
}
