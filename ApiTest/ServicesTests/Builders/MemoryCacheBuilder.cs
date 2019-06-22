using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace ServicesTests.Builders
{
    public class MemoryCacheBuilder
    {
        private Mock<IMemoryCache> _mockMemoryCache;

        public MemoryCacheBuilder()
        {
            _mockMemoryCache = new Mock<IMemoryCache>();
        }

        public IMemoryCache Build()
        {
            return _mockMemoryCache.Object;
        }
    }
}
