using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Services.Http
{
    public class HttpWrapper<T> : IHttpWrapper<T>
    {
        public async Task<T> MakeHttpCall(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new ArgumentException($"{nameof(url)} is an invalid Uri. {nameof(url)} - {url}");

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
