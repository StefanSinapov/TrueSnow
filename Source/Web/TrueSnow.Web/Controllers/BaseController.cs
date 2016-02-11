namespace TrueSnow.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Web.Contracts;

    public class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}
