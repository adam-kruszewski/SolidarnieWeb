using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace SolidarnieWebApp.Authentication
{
    public class WymagaLogowaniaAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var cookie = filterContext.RequestContext.HttpContext.Request.Cookies["solidarnie"];

            if (cookie != null)
            {
            }else
            {
                //filterContext.HttpContext.Request.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new {
                        controller = "Logowanie",
                        action = "Login",
                    returnUrl  = filterContext.HttpContext.Request.RawUrl }));

                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
        }

        public void OnAuthenticationChallenge(
            AuthenticationChallengeContext filterContext)
        {
        }
    }
}