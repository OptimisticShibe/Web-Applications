using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloWorld
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        // To handle exception for the entire application
        protected void Application_Error()
        {
            var exception = Server.GetLastError();

            Server.ClearError();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Error");

            IController errorController = new Controllers.ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }

    }
}
