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

        // This would need to be expanded and tested properly.
        // But due to time constraints this will be left untested. 
        // TODO AT: Consider using a FakeMemoryCache instead
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
