using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class LocalAccessOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/");
            }


        }
    }
}