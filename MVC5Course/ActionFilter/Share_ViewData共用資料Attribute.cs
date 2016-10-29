using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class Share_ViewData共用資料Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.Controller.ViewData["Test"] = "Show me the money";

        }

    }
}