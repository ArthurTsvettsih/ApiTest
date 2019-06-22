using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Services.Http;
using ServicesTests.Builders;
using ServicesTests.Fixtures;

namespace ServicesTests.Tests
{
    [TestFixture]
    class HttpWrapperTests
    {
        [Test]
        public void WhenPassedInvalidUrl_ThrowsArgumentException()
        {
            // Arrange
            var memoryCache = new MemoryCacheBuilder().Build();
            var sut = new HttpWrapperFixture<string>(memoryCache).Build();

            // Act + Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await sut.MakeHttpCall(Guid.NewGuid().ToString()));
        }
    }
}
