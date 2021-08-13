using IckleUrl.Context;
using IckleUrl.Service;
using Moq.EntityFramework;
using Xunit;
using IckleUrl.Controllers;
using System.Web.Mvc;
using IckleUrl.Models;


namespace IckleUrl.Tests
{
    public class IckeUrlMvcControllerTests
    {

        [Fact]
        public void View_Is_Loaded()
        {
            var context = DbContextMockFactory.Create<IckleUrlContext>();
            var service = new IckleUrlService(context.Object);
            var controller = new IckleUrlController(service);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public async void Index_Task_Returns_View()
        {

            var httpContext = TestHelpers.CreateMockHttpContextAndRequest();
            var context = TestHelpers.CreateAndSeedMockBackEnd();
            var service = new IckleUrlService(context.Object);
            var controller = new IckleUrlController(service);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new System.Web.Routing.RouteData(), controller);  


            var shortUrl = new ShortUrl() { FullUrl = "https://www.bbc.co.uk"};

            var result = await controller.Index(shortUrl);


            Assert.IsType<ViewResult>(result);

        }

        [Fact]
        public async void Click_Returns_Url_For_Redirect()
        {
            var pointer = "123456";
            var context = TestHelpers.CreateAndSeedMockBackEnd();
            var service = new IckleUrlService(context.Object);
            var controller = new IckleUrlController(service);

            var result = await controller.Click(pointer);

            Assert.IsType<RedirectResult>(result);
        }

        
    }
}
