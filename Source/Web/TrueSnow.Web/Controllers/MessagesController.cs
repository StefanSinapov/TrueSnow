﻿namespace TrueSnow.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class MessagesController : BaseController
    {
        public ActionResult ByUser()
        {
            return this.View();
        }
    }
}