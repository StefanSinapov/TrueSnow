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

        public ActionResult ByPost(int id)
        {
            var viewModel = this.comments
                .GetByPostId(id)
                .To<CommentViewModel>()
                .ToList();

            return this.PartialView("ByPost", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputCommentViewModel comment)
        {
            if (this.ModelState.IsValid)
            {
                var commentToAdd = new Comment
                {
                    Content = comment.Content,
                    CreatorId = this.HttpContext.User.Identity.GetUserId(),
                    PostId = comment.PostId
                };

                this.comments.Add(commentToAdd);
            }

            return this.Redirect(this.Request.UrlReferrer.ToString());
        }
    }
}
