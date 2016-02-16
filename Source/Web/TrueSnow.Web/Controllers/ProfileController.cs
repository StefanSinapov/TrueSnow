namespace TrueSnow.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Models.Users;
    using Microsoft.AspNet.Identity.Owin;
    using Config;
    using Data.Models;

    public class ProfileController : BaseController
    {
        private ApplicationUserManager userManager;
        private TrueSnow.Data.TrueSnowDbContext db = new Data.TrueSnowDbContext();

        public ProfileController()
        {
        }

        public ProfileController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        public ActionResult Index(string id)
        {
            var user = this.UserManager.FindById(id);
            var model = this.Mapper.Map<ProfileViewModel>(user);

            return this.View(model);
        }

        public ActionResult GetUser()
        {
            var userId = this.HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(userId);
            var model = this.Mapper.Map<ProfileViewModel>(currentUser);

            return this.PartialView("GetUser", model);
        }

        public ActionResult Edit(string id)
        {
            var userToEdit = this.UserManager.FindById(id);
            var model = this.Mapper.Map<ProfileViewModel>(userToEdit);

            var currentUserId = this.HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(currentUserId);
            var userToFollow = this.UserManager.FindById(id);
            currentUser.Following.Add(userToFollow);
            this.db.SaveChanges();

            return this.View(model);
        }

        //public void Follow()
        //{
        //    string userToFollowId = "";
        //    var currentUserId = this.HttpContext.User.Identity.GetUserId();
        //    var currentUser = this.UserManager.FindById(currentUserId);
        //    var userToFollow = this.UserManager.FindById(userToFollowId);
        //    currentUser.Following.Add(userToFollow);
        //}

        //public void Unfollow(string userToUnfollowId)
        //{
        //    var currentUserId = this.HttpContext.User.Identity.GetUserId();
        //    var currentUser = this.UserManager.FindById(currentUserId);
        //    var userToUnfollow = this.UserManager.FindById(userToUnfollowId);
        //    currentUser.Following.Remove(userToUnfollow);
        //}
    }
}
