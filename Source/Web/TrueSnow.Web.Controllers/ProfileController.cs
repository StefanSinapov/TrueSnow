namespace TrueSnow.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Data.Services.Contracts;
    using Models.Users;

    public class ProfileController : Controller
    {
        private IUsersService users;

        public ProfileController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var currentUser = this.users.GetById(userId);
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
    }
}
