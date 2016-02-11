namespace TrueSnow.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Models.Users;
    using Microsoft.AspNet.Identity.Owin;

    public class ProfileController : BaseController
    {
        private ApplicationUserManager _userManager;

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
                return this._userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this._userManager = value;
            }
        }
        
        public ActionResult Index()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(userId);

            var model = new ProfileViewModel
            {
                Id = currentUser.Id,
                ScreenName = currentUser.ScreenName,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Files = currentUser.Files
            };

            return View(model);
        }

        public ActionResult GetUser()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var currentUser = this.UserManager.FindById(userId);

            var model = new ProfileViewModel
            {
                Id = currentUser.Id,
                ScreenName = currentUser.ScreenName,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Files = currentUser.Files
            };

            return PartialView("GetUser", model);
        }
    }
}
