namespace TrueSnow.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity;
    using Models;
    public class ProfileController : Controller
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
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var currentUser = UserManager.FindById(userId);
            var model = new ProfileViewModel
            {
                ScreenName = currentUser.ScreenName,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Files = currentUser.Files
            };

            return View(model);
        }
    }
}
