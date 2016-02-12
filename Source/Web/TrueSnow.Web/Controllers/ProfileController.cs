namespace TrueSnow.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Models.Users;
    using Microsoft.AspNet.Identity.Owin;
    using Config;

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

        public ActionResult Index()
        {
            var userId = this.HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(userId);
            var model = this.Mapper.Map<ProfileViewModel>(currentUser);

            return this.View(model);
        }

        public ActionResult GetUser()
        {
            var userId = this.HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(userId);
            var model = this.Mapper.Map<ProfileViewModel>(currentUser);

            return this.PartialView("GetUser", model);
        }
    }
}
