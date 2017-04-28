using System;
using System.Web.Mvc;

namespace HelloWorld
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class IsAdministratorAttribute : FilterAttribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (filterContext.HttpContext.Session != null && // Make sure session isn't null
                filterContext.HttpContext.Session["User"] != null) // Make sure they're a user
            {
                var user = (Models.User)filterContext.HttpContext.Session["User"];

                if (!user.IsAdmin)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}