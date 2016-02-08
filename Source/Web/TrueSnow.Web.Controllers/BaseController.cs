namespace TrueSnow.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using Data.Services.Contracts;
    using Models;

    public class BaseController : Controller
    {
        protected IUsersService users;

        public BaseController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            var currentUserId = HttpContext.User.Identity.GetUserId();
            var currentUser = this.users.GetById(currentUserId);

            var model = new BaseViewModel
            {
                Files = currentUser.Files,
                ScreenName = currentUser.ScreenName
            };

            return this.View(model);
        }
    }
}
