namespace TrueSnow.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Data.Services.Contracts;
    using Models.Posts;
    using System;
    using Data.Models;
    public class PostsController : Controller
    {
        private IPostsService posts;

        public PostsController(IPostsService posts)
        {
            this.posts = posts;
        }

        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                var postsViewModel = this.posts
                    .GetAll()
                    .Select(p => new PostViewModel
                    {
                        Title = p.Title,
                        Content = p.Content,
                        CreatedOn = p.CreatedOn,
                        Files = p.Files,
                        CreatorId = p.CreatorId
                    })
                    .ToList();

                return PartialView("Index", postsViewModel);
            }
            else
            {
                var postsViewModel = this.posts
                    .GetByUserId(id)
                    .Select(p => new PostViewModel
                    {
                        Title = p.Title,
                        Content = p.Content,
                        CreatedOn = p.CreatedOn,
                        Files = p.Files,
                        CreatorId = p.CreatorId
                    })
                    .ToList();

                return PartialView("Index", postsViewModel);
            }
        }

        public ActionResult Create(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var postToAdd = new Post
                {
                    Title = post.Title,
                    Content = post.Content,
                    Files = post.Files,
                    CreatedOn = DateTime.UtcNow,
                    CreatorId = HttpContext.User.Identity.GetUserId()
                };

                this.posts.Add(postToAdd);
            }

            return View(post);
        }
    }
}
