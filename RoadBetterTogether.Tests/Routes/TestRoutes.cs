using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Routing;

namespace RoadBetterTogether.Tests.Routes
{
    [TestClass]
    public class RoutesTests
    {

        private static RouteData getRouteData(string url)
        {
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            RouteCollection route = new RouteCollection();
            RouteConfig.RegisterRoutes(route);
            return route.GetRouteData(mockContext.Object);
        }


        [TestMethod]
        public void TestRoutes()
        {
            RouteData data = getRouteData("~/Ajouter/User");
            Assert.AreEqual("Home", data.Values["controller"]);
            Assert.AreEqual("AjouterUser", data.Values["action"]);
        }
    }
}
