﻿namespace TrueSnow.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data.Contracts;
    using TrueSnow.Data.Models;
    using ViewModels.Comments;
    using Microsoft.AspNet.Identity;
    using Infrastructure.Mapping;
    using System.Globalization;
    [Authorize]
    public class CommentsController : BaseController
    {
        private const int CommentsPerPage = 5;
        private readonly ICommentsService comments;
        private readonly UserManager<User> userManager;

        public CommentsController(ICommentsService comments, UserManager<User> userManager)
        {
            this.comments = comments;
            this.userManager = userManager;
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
                    CreatorId = this.User.Identity.GetUserId(),
                    PostId = comment.PostId
                };

                this.comments.Add(commentToAdd);

                var currentUser = this.userManager.FindById(this.User.Identity.GetUserId());
                var creatorAvatarId = currentUser.Files.First(x => x.FileType == FileType.Avatar).Id;
                var creatorFullname = currentUser.FirstName + " " + currentUser.LastName;
                var createdOnStr = commentToAdd.CreatedOn.ToString("dd MMM HH:mm", CultureInfo.CreateSpecificCulture("en-US"));
                var commentsCount = this.comments.CommentCountByPost(comment.PostId);

                return this.Json(
                    new
                    {
                        Content = commentToAdd.Content,
                        CreatorId = currentUser.Id,
                        CreatorName = creatorFullname,
                        CreatorAvatarId = creatorAvatarId,
                        CreatedOn = createdOnStr,
                        PostId = comment.PostId,
                        CommentsCount = commentsCount
                    });
            }

            return this.Redirect(this.Request.UrlReferrer.ToString());
        }
    }
}
