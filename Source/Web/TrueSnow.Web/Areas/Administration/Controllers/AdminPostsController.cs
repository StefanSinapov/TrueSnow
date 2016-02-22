namespace TrueSnow.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using ViewModels;

    public class AdminPostsController : Controller
    {
        private readonly IDbRepository<Post> posts;

        public AdminPostsController(IDbRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Posts_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.posts
                .All()
                .ToDataSourceResult(request, post => new AdminPostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Creator = post.Creator.FirstName + " " + post.Creator.LastName
                });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Update([DataSourceRequest]DataSourceRequest request, AdminPostViewModel post)
        {
            var postToUpdate = this.posts.All().First(x => x.Id == post.Id);
            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;
            this.posts.Save();

            return this.Json(new[] { post }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Destroy([DataSourceRequest]DataSourceRequest request, Post post)
        {
            var postToDelete = this.posts.All().First(x => x.Id == post.Id);
            this.posts.Delete(postToDelete);
            this.posts.Save();

            return this.Json(new[] { post }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
