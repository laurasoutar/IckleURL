using IckleUrl.Service;
using Xunit;
using IckleUrl.API;
using System;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;

namespace IckleUrl.Tests
{
    public class IckleUrlApiControllerTests
    {


        [Fact]
        public async void MakeSmallUrl_Is_called_When_Request_Sent_To_Contoller()
        {
            var _mockContext = TestHelpers.CreateAndSeedMockBackEnd();
            var _service = new IckleUrlService(_mockContext.Object);
            var _apiController = new IckleUrlApiController(_service);

            _apiController.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/ickleurlapi/shorten")    
            };

            _apiController.Configuration = new HttpConfiguration();
            _apiController.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            _apiController.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "ickleurlapi" } });

            var response = await _apiController.MakeSmallUrl("https://www.bbc.co.uk");

            Assert.NotNull(response);


        }

    }
    
}
