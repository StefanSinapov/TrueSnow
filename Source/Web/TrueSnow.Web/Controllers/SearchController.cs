namespace TrueSnow.Web.Controllers
{
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Models.Users;
    public class SearchController : BaseController
    {
        private readonly UserManager<User> userManager;

        public SearchController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult GetSearch()
        {
            return this.PartialView("GetSearch");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string query)
        {
            var model = this.userManager
                .Users
                .Where(x => x.FirstName.ToLower().Contains(query.ToLower()) || x.LastName.ToLower().Contains(query.ToLower()))
                .To<ProfileViewModel>()
                .ToList();

            return this.View(model);
        }
    }
}