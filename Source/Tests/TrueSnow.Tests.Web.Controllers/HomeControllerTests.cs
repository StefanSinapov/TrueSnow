namespace TrueSnow.Tests.Web.Controllers
{
    using System.Web.Mvc;

    using NUnit.Framework;
    using TrueSnow.Web.Controllers;

    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void HomeControllerReturnsTheDefaultView()
        {
            string expected = "Index";
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }
    }
}
