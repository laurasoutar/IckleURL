using IckleUrl.Context;
using IckleUrl.Entities;
using Moq;
using Moq.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IckleUrl.Tests
{
    public class TestHelpers
    {
        public static DbContextMock<IckleUrlContext> CreateAndSeedMockBackEnd()
        {
            var _mockContext = DbContextMockFactory.Create<IckleUrlContext>();
            var data = new List<SmallUrl>
            {
                new SmallUrl { FullUrl = "https://www.bbc.co.uk", Ip = "127.0.0.0.1", Pointer = "123456" },
                new SmallUrl { FullUrl = "https://www.bbc.com", Ip = "127.0.0.0.1", Pointer = "654321" },
                new SmallUrl { FullUrl = "https://www.twitter.com", Ip = "127.0.0.0.1", Pointer = "321456" },
            }.AsQueryable();

            var mockSet = _mockContext.MockedSet<SmallUrl>();
            mockSet.As<IQueryable<SmallUrl>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<SmallUrl>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<SmallUrl>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<SmallUrl>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return _mockContext;
        }

        public static Mock<HttpContextBase> CreateMockHttpContextAndRequest()
        {
            var request = new Mock<HttpRequestBase>();
            request.SetupGet(x => x.UserHostAddress).Returns("127.0.0.0.1");
            request.SetupGet(x => x.Url).Returns(new System.Uri("https://localhost:12345"));
            var httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(x => x.Request).Returns(request.Object);

            return httpContext;
        }

    }
}
