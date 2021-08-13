using System.Collections.Generic;
using System.Linq;
using IckleUrl.Context;
using IckleUrl.Entities;
using IckleUrl.Service;
using Moq.EntityFramework;
using Moq;
using Xunit;

namespace IckleUrl.Tests
{
    public class IckleUrlServiceTests
    {

        [Fact]
        public async void New_SmallURL_Is_Created()
        {
            var _mockContext = DbContextMockFactory.Create<IckleUrlContext>();
            var url = new SmallUrl() { FullUrl = "https://www.bbc.co.uk", Ip = "127.0.0.0.1" };
            var setMock = _mockContext.MockedSet<SmallUrl>();
            var service = new IckleUrlService(_mockContext.Object);

            var returned = await service.MakeUrlShorter(url.FullUrl, url.Ip);

            setMock.Verify(s => s.Add(returned), Times.Once);
            Assert.Equal(url.FullUrl, returned.FullUrl);
        }

        [Fact]
        public async void Exisiting_SmallUrl_Is_Returned_From_Exisiting_FullUrl()
        {
            var url = new SmallUrl() { FullUrl = "https://www.bbc.co.uk", Ip = "127.0.0.0.1" };

            var _mockContext = TestHelpers.CreateAndSeedMockBackEnd();

            var service = new IckleUrlService(_mockContext.Object);

            var returned = await service.MakeUrlShorter(url.FullUrl, url.Ip);

            Assert.Equal("123456", returned.Pointer);

        }


        [Fact]
        public async void LongUrl_Is_Retrieved()
        {
            const string pointer = "123456";

            var _mockContext = TestHelpers.CreateAndSeedMockBackEnd();
            
            var service = new IckleUrlService(_mockContext.Object);

            var url = await service.GetSmallUrl(pointer);

            Assert.Equal("https://www.bbc.co.uk", url.FullUrl);
        }


    }
}
