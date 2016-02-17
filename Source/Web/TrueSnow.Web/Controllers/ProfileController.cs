namespace TrueSnow.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Models.Users;
    using Data.Models;

    public class ProfileController : BaseController
    {
        private readonly UserManager<User> userManager;

        public ProfileController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Index(string id)
        {
            this.TempData["userId"] = id;
            var user = this.userManager.FindById(id);
            var model = this.Mapper.Map<ProfileViewModel>(user);

            return this.View(model);
        }

        public ActionResult GetUser()
        {
            var userId = this.HttpContext.User.Identity.GetUserId();
            var currentUser = this.userManager.FindById(userId);
            var model = this.Mapper.Map<ProfileViewModel>(currentUser);

            return this.PartialView("GetUser", model);
        }
    }
}
