// namespace TrueSnow.Tests.Web.Controllers
// {
//    using Data.Models;
//    using Moq;
//    using NUnit.Framework;
//    using Services.Data.Contracts;
//    using TrueSnow.Web.Controllers;
//    using TrueSnow.Web.Infrastructure.Mapping;

// [TestFixture]
//    public class ArticlesControllerTests
//    {
//        [Test]
//        public void ArticlesByIdShouldWorkCorrectly()
//        {
//            var autoMapperConfig = new AutoMapperConfig();
//            autoMapperConfig.Execute(typeof(ArticlesController).Assembly);
//            const string ArticleContent = "SomeContent";
//            var articlesServiceMock = new Mock<IArticlesService>();
//            articlesServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
//                .Returns(new Article { Content = ArticleContent, Category = new JokeCategory { Name = "asda" } });
//            var controller = new JokesController(articlesServiceMock.Object);
//            controller.WithCallTo(x => x.ById("asdasasd"))
//                .ShouldRenderView("ById")
//                .WithModel<JokeViewModel>(
//                    viewModel =>
//                    {
//                        Assert.AreEqual(ArticleContent, viewModel.Content);
//                    }).AndNoModelErrors();
//        }
//    }
// }
