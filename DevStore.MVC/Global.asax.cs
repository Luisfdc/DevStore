using DevStore.Infra.IoC;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevStore.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //DependencyResolver.SetResolver(SimpleInjectorContainer.RegisterServices());
        }
    }
}
