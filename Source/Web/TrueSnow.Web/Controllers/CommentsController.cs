namespace TrueSnow.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Data.Contracts;
    using TrueSnow.Data.Models;
    using ViewModels.Comments;
    using Microsoft.AspNet.Identity;
    using Infrastructure.Mapping;
    using System;
    public class CommentsController : BaseController
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        public ActionResult ByPost(int id)
        {
            this.TempData["currentPostId"] = id;
            var model = this.comments
                .GetByPostId(id)
                .To<CommentViewModel>()
                .ToList();

            return this.PartialView("ByPost", model);
        }

        public ActionResult GetCreate()
        {
            return this.PartialView("Create");
        }

        public ActionResult Create(CommentViewModel comment)
        {
            if (this.ModelState.IsValid && this.HttpContext.User.Identity.GetUserId() != null)
            {
                var commentToAdd = new Comment
                {
                    Content = comment.Content,
                    CreatorId = this.HttpContext.User.Identity.GetUserId(),
                    PostId = Convert.ToInt32(this.TempData["currentPostId"])
                };

                this.comments.Add(commentToAdd);

                return this.Redirect(this.Request.RawUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }

        //// GET: Comments/Create
        // public ActionResult Create()
        // {
        //    ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName");
        //    return View();
        // }

        //// POST: Comments/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Create([Bind(Include = "Id,Content,CreatorId,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] Comment comment)
        // {
        //    if (ModelState.IsValid)
        //    {
        //        db.Comments.Add(comment);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        // ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName", comment.CreatorId);
        //    return View(comment);
        // }

        //// GET: Comments/Edit/5
        // public async Task<ActionResult> Edit(int? id)
        // {
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comment comment = await db.Comments.FindAsync(id);
        //    if (comment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName", comment.CreatorId);
        //    return View(comment);
        // }

        //// POST: Comments/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Edit([Bind(Include = "Id,Content,CreatorId,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] Comment comment)
        // {
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(comment).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CreatorId = new SelectList(db.Users, "Id", "FirstName", comment.CreatorId);
        //    return View(comment);
        // }

        //// GET: Comments/Delete/5
        // public async Task<ActionResult> Delete(int? id)
        // {
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comment comment = await db.Comments.FindAsync(id);
        //    if (comment == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comment);
        // }

        //// POST: Comments/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> DeleteConfirmed(int id)
        // {
        //    Comment comment = await db.Comments.FindAsync(id);
        //    db.Comments.Remove(comment);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        // }
    }
}
