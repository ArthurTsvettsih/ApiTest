using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Services.Http;

namespace ServicesTests.Tests
{
    [TestFixture]
    class HttpWrapperTests
    {
        [Test]
        public void WhenPassedInvalidUrl_ThrowsArgumentException()
        {
            // This is the only thing we can test as a unit. Everything else is an integration test

            // Arrange
            var sut = new HttpWrapper<string>();

            // Act + Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await sut.MakeHttpCall(Guid.NewGuid().ToString()));
        }
    }
}
