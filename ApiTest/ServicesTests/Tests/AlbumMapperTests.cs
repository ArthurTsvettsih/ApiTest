using System;
using System.Collections.Generic;
using System.Text;
using Models;
using NUnit.Framework;
using Services.Mappers;
using ServicesTests.Builders;

namespace ServicesTests.Tests
{
    [TestFixture]
    class AlbumMapperTests
    {
        [Test]
        public void WhenPassedNullAlbums_ThrowsArgumentException()
        {
            // Arrange
            var sut = new AlbumMapper();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => sut.MapItems(null, new List<Photo>()));
        }

        [Test]
        public void WhenPassedNullPhotos_ThrowsArgumentException()
        {
            // Arrange
            var sut = new AlbumMapper();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => sut.MapItems(new List<Album>(), null));
        }

        [Test]
        public void WhenPassedNulls_ThrowsArgumentException()
        {
            // Arrange
            var sut = new AlbumMapper();

            // Act + Assert
            Assert.Throws<ArgumentException>(() => sut.MapItems(null, null));
        }

        [Test]
        public void WhenPassedNoAlbums_MapsCorrectly()
        {
            // Arrange
            var testBuilder = new AlbumMapperListBuilder()
                .WithPhoto(1, 1)
                .WithPhoto(2, 2);

            var sut = new AlbumMapper();

            // Act
            sut.MapItems(testBuilder.Albums, testBuilder.Photos);

            // Assert
            Assert.AreEqual(testBuilder.Albums.Count, 0);
        }

        [Test]
        public void WhenPassedNoPhotos_MapsCorrectly()
        {
            // Arrange
            var testBuilder = new AlbumMapperListBuilder()
                .WithAlbum(1, "First")
                .WithAlbum(2, "Second");

            var sut = new AlbumMapper();

            // Act
            sut.MapItems(testBuilder.Albums, testBuilder.Photos);

            // Assert
            Assert.AreEqual(testBuilder.Albums[0].Photos.Count, 0);
            Assert.AreEqual(testBuilder.Albums[1].Photos.Count, 0);
        }

        [Test]
        public void WhenPassedOneToOneMappings_MapsCorrectly()
        {
            // Arrange
            var testBuilder = new AlbumMapperListBuilder()
                .WithAlbum(1, "First")
                .WithPhoto(1, 1);

            var sut = new AlbumMapper();

            // Act
            sut.MapItems(testBuilder.Albums, testBuilder.Photos);

            // Assert
            Assert.AreEqual(testBuilder.Albums[0].Photos.Count, 1);
        }

        [Test]
        public void WhenPassedOneToManyMappings_MapsCorrectly()
        {
            // Arrange
            var testBuilder = new AlbumMapperListBuilder()
                .WithAlbum(1, "First")
                .WithPhoto(1, 1)
                .WithPhoto(1, 2)
                .WithPhoto(1, 3);

            var sut = new AlbumMapper();

            // Act
            sut.MapItems(testBuilder.Albums, testBuilder.Photos);

            // Assert
            Assert.AreEqual(testBuilder.Albums[0].Photos.Count, 3);
        }

        [Test]
        public void WhenPassedComplexScenario_MapsCorrectly()
        {
            // Arrange
            var testBuilder = new AlbumMapperListBuilder()
                .WithAlbum(1, "First")
                .WithAlbum(2, "Second")
                .WithAlbum(3, "Third")
                .WithAlbum(4, "Fourth")

                .WithPhoto(1, 1)
                .WithPhoto(1, 2)
                .WithPhoto(1, 3)

                .WithPhoto(2, 4)
                .WithPhoto(2, 5)

                .WithPhoto(4, 6);

            var sut = new AlbumMapper();

            // Act
            sut.MapItems(testBuilder.Albums, testBuilder.Photos);

            // Assert
            Assert.AreEqual(testBuilder.Albums[0].Photos.Count, 3);
            Assert.AreEqual(testBuilder.Albums[1].Photos.Count, 2);
            Assert.AreEqual(testBuilder.Albums[2].Photos.Count, 0);
            Assert.AreEqual(testBuilder.Albums[3].Photos.Count, 1);
        }

    }
}
