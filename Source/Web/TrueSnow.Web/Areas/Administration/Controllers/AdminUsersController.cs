namespace TrueSnow.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TrueSnow.Data.Models;
    using ViewModels;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    public class AdminUsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IPostsService posts;
        private readonly ICommentsService comments;

        public AdminUsersController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<User> users = this.userManager.Users;
            DataSourceResult result = users
                .ToDataSourceResult(request, user => new AdminUserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, AdminUserViewModel user)
        {
            var userToUpdate = this.userManager.FindById(user.Id);
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, AdminUserViewModel user)
        {
            var userToDelete = this.userManager.FindById(user.Id);
            var logins = userToDelete.Logins;

            foreach (var login in logins)
            {
                var loginResult = this.userManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            var userRoles = this.userManager.GetRoles(userToDelete.Id);

            if (userRoles.Count() > 0)
            {
                foreach (var item in userRoles.ToList())
                {
                    var roleResult = this.userManager.RemoveFromRole(userToDelete.Id, "User"); // Only Users can be deleted (not Admins)
                }
            }

            var result = this.userManager.Delete(userToDelete);
            if (result.Succeeded)
            {
                return this.RedirectToAction("Index", "Home");
            }
            else
            {

            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
