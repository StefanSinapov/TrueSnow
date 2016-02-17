namespace TrueSnow.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data.Contracts;
    using TrueSnow.Data.Models;
    using ViewModels.Comments;
    using Microsoft.AspNet.Identity;
    using Infrastructure.Mapping;

    public class CommentsController : BaseController
    {
        private const int CommentsPerPage = 5;
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        public ActionResult ByPost(int id, int? page, string postUrl)
        {
            if (page == null)
            {
                page = 1;
            }

            var allCommentsCount = this.comments.GetByPostId(id).Count();
            var totalPages = (int)Math.Ceiling(allCommentsCount / (decimal)CommentsPerPage);
            var commentsToSkip = (int)(page - 1) * CommentsPerPage;

            this.TempData["currentPostId"] = id;
            var comments = this.comments
                .GetByPostId(id)
                .Skip(commentsToSkip)
                .Take(CommentsPerPage)
                .To<CommentViewModel>()
                .ToList();

            var viewModel = new CommentsByPostViewModel
            {
                Comments = comments,
                TotalPages = totalPages,
                PostUrl = postUrl,
                CurrentPage = (int)page,
                NextPage = (int)(page == totalPages ? totalPages : page + 1),
                PreviousPage = (int)(page == 1 ? 1 : page - 1)
            };

            return this.PartialView("ByPost", viewModel);
        }

        public ActionResult GetCreate()
        {
            return this.PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel comment)
        {
            if (this.ModelState.IsValid)
            {
                var commentToAdd = new Comment
                {
                    Content = comment.Content,
                    CreatorId = this.HttpContext.User.Identity.GetUserId(),
                    PostId = Convert.ToInt32(this.TempData["currentPostId"])
                };

                this.comments.Add(commentToAdd);
            }

            return this.Redirect(this.Request.UrlReferrer.ToString());
        }
    }
}
