namespace TrueSnow.Web.Areas.Administration.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Data;
    using Data.Models;
    using Infrastructure.Constants;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Web.Controllers;

    [Authorize(Roles = IdentityRoles.Administrator)]
    public class AdminPostsController : BaseController
    {
        private TrueSnowDbContext db = new TrueSnowDbContext();

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Posts_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Post> posts = this.db.Posts;
            DataSourceResult result = posts.ToDataSourceResult(request, post => new
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedOn = post.CreatedOn,
                ModifiedOn = post.ModifiedOn,
                IsDeleted = post.IsDeleted,
                DeletedOn = post.DeletedOn
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Create([DataSourceRequest]DataSourceRequest request, Post post)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    CreatedOn = post.CreatedOn,
                    ModifiedOn = post.ModifiedOn,
                    IsDeleted = post.IsDeleted,
                    DeletedOn = post.DeletedOn
                };

                this.db.Posts.Add(entity);
                this.db.SaveChanges();
                post.Id = entity.Id;
            }

            return this.Json(new[] { post }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Update([DataSourceRequest]DataSourceRequest request, Post post)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new Post
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    CreatedOn = post.CreatedOn,
                    ModifiedOn = post.ModifiedOn,
                    IsDeleted = post.IsDeleted,
                    DeletedOn = post.DeletedOn
                };

                this.db.Posts.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { post }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Destroy([DataSourceRequest]DataSourceRequest request, Post post)
        {
            var entity = new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedOn = post.CreatedOn,
                ModifiedOn = post.ModifiedOn,
                IsDeleted = post.IsDeleted,
                DeletedOn = post.DeletedOn
            };

            this.db.Posts.Attach(entity);
            this.db.Posts.Remove(entity);
            this.db.SaveChanges();

            return this.Json(new[] { post }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}
