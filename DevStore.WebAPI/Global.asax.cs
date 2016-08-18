using DevStore.Infra.IoC;
using System.Web.Http;
using System.Web.Mvc;

namespace DevStore.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);
            //IoC.Int();

            //DependencyResolver.SetResolver(SimpleInjectorContainer.RegisterServices());
        }
    }
}
