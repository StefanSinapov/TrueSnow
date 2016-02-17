namespace TrueSnow.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Web.Contracts;
    using Data.Models;

    public abstract class BaseController : Controller
    {
        protected ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        //protected User CurrentUser { get; private set; }

        //protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        //{
        //    if (this.User.Identity.IsAuthenticated)
        //    {
        //        this.CurrentUser = 
        //    }

        //    return base.BeginExecute(requestContext, callback, state);
        //}
    }
}
