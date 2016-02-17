using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TrueSnow.Data.Models;
using TrueSnow.Data;

namespace TrueSnow.Web.Areas.Administration.Controllers
{
    public class AdminPostsController : Controller
    {
        private TrueSnowDbContext db = new TrueSnowDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Posts_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Post> posts = db.Posts;
            DataSourceResult result = posts.ToDataSourceResult(request, post => new {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedOn = post.CreatedOn,
                ModifiedOn = post.ModifiedOn,
                IsDeleted = post.IsDeleted,
                DeletedOn = post.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Create([DataSourceRequest]DataSourceRequest request, Post post)
        {
            if (ModelState.IsValid)
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

                db.Posts.Add(entity);
                db.SaveChanges();
                post.Id = entity.Id;
            }

            return Json(new[] { post }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Update([DataSourceRequest]DataSourceRequest request, Post post)
        {
            if (ModelState.IsValid)
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

                db.Posts.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { post }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Posts_Destroy([DataSourceRequest]DataSourceRequest request, Post post)
        {
            if (ModelState.IsValid)
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

                db.Posts.Attach(entity);
                db.Posts.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { post }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
