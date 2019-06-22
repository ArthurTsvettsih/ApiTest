using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Services.Http;

namespace ServicesTests.Fixtures
{
    class HttpWrapperFixture<T>
    {
        private IMemoryCache _memoryCache;

        public HttpWrapperFixture(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public HttpWrapper<T> Build()
        {
            return new HttpWrapper<T>(_memoryCache);
        }
    }
}
