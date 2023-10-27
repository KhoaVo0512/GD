using System.Web.Mvc;
using System.Web.Routing;

namespace GD.Web
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (SessionHelper.MenuGlobal == null || SessionHelper.MenuGroupGlobal == null || SessionHelper.Information == null)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
        }
    }
}