using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection; // Advanced C# topic (backend). Add this for assembly
using Autofac;
using Autofac.Integration.Mvc;

namespace HelloWorld
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterAutofac(); // as application starts, Autofac gets called
        }

        // Autofac registration
        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces();

            //builder.RegisterType<ContactRepository>().As<IContactRepository>();

            var container = builder.Build();

            // Configure dependency resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void xxApplication_Error() // Do xx before doing Cookie
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