namespace TrueSnow.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Config;
    using Models.Users;

    public class ProfileController : BaseController
    {
        private ApplicationUserManager userManager;

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

        public ActionResult Follow(string id)
        {
            var currentUserId = this.HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(currentUserId);

            var userToFollow = this.UserManager.FindById(id);

            currentUser.Following.Add(userToFollow);
            this.UserManager.Update(currentUser);

            var allusers = currentUser.Following.ToList();

            return this.View("Index", this.Mapper.Map<ProfileViewModel>(userToFollow));
        }

        public ActionResult Unfollow(string id)
        {
            var currentUserId = this.HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(currentUserId);

            var userToUnfollow = this.UserManager.FindById(id);

            currentUser.Following.Remove(userToUnfollow);
            this.UserManager.Update(currentUser);

            var allusers = currentUser.Following.ToList();

            return this.View("Index", this.Mapper.Map<ProfileViewModel>(userToUnfollow));
        }
    }
}
