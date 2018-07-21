using System.Web.Mvc;
using System.Configuration;
using System.Web;

namespace HCS.StaffManagement.Filter
{
    public class SessionTimeoutAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["ID"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/LoginPage");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}