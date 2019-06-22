using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Http
{
    public class HttpWrapper<T> : IHttpWrapper<T>
    {
        public Task<T> MakeHttpCall(string url)
        {
            throw new NotImplementedException();
        }
    }
}
