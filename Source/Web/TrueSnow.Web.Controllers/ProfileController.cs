namespace TrueSnow.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Models.Users;

    public class ProfileController : BaseController
    {
        private ApplicationUserManager userManager;

        public ProfileController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var currentUser = this.userManager.FindById(userId);

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
            var currentUser = this.userManager.FindById(userId);

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
