namespace TrueSnow.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Data.Models;
    using Models.Posts;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;

    public class PostsController : BaseController
    {
        private readonly IPostsService posts;

        public PostsController(IPostsService posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            var postsViewModel = this.posts
                .GetAll()
                .To<PostViewModel>()
                .ToList();

            return this.PartialView("Index", postsViewModel);
        }

        public ActionResult ById(string id)
        {
            var post = this.posts.GetById(id);
            var model = this.Mapper.Map<PostViewModel>(post);
            return this.View("ById", model);
        }

        public ActionResult ByUserId()
        {
            var currentUserId = this.HttpContext.User.Identity.GetUserId();

            var postsViewModel = this.posts
                .GetByUserId(currentUserId)
                .To<PostViewModel>()
                .ToList();

            return this.PartialView("ByUser", postsViewModel);
        }

        public ActionResult GetCreate()
        {
            return this.PartialView("Create");
        }

        public ActionResult Create(PostViewModel post, HttpPostedFileBase upload)
        {
            if (this.ModelState.IsValid)
            {
                var postToAdd = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    CreatedOn = DateTime.Now,
                    CreatorId = this.HttpContext.User.Identity.GetUserId()
                };

                if (upload != null && upload.ContentLength > 0)
                {
                    var photo = new Data.Models.File
                    {
                        FileName = Path.GetFileName(upload.FileName),
                        FileType = FileType.Photo,
                        ContentType = upload.ContentType
                    };

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        photo.Content = reader.ReadBytes(upload.ContentLength);
                    }

                    postToAdd.Files = new List<Data.Models.File> { photo };
                }

                this.posts.Add(postToAdd);

                return this.Redirect(this.Request.RawUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
