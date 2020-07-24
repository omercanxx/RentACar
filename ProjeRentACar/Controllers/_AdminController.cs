using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeRentACar.Controllers
{
    public class _AdminControllerAttribute : ActionFilterAttribute
    {
        // GET: _Admin
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                    filterContext.HttpContext.Response.Redirect("/Admin/login");
                }
            }
        }
    }
}