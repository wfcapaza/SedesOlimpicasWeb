using System.Web;
using System.Web.Mvc;

namespace SedesOlimpicas.Helpers
{
    public class ValidarSesionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/InicioSesion");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}