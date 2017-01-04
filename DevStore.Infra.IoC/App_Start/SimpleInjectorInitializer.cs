[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(DevStore.Infra.IoC.App_Start.SimpleInjectorInitializer), "Initialize")]


namespace DevStore.Infra.IoC.App_Start
{
    using CommonServiceLocator.SimpleInjectorAdapter;
    using Microsoft.Practices.ServiceLocation;
    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Http;
    using SimpleInjector.Integration.WebApi;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            /// <summary>Codigo para MVC.</summary>
            
            var container = new Container();

            InitializeContainer(container);


            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();
            // Essa expressão Lambda abaixo (() => new SimpleInjectorServiceLocatorAdapter(container)), esta fazendo uma "parse" do tipo 
            // SimpleInjectorServiceLocatorAdapter para o ServicerLocatorProvider, que o é esperado. Isso só é possível por causa da Interfaces que 
            // são comuns para as tudas classes, a interface IServiceLocator;
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));

            // Para pegar a instância do Objeto informado, só fazer: var objProduto = ServiceLocator.Current.GetInstance<IProduto>();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));


            /// <summary>Codigo para WepApi.</summary>
            /// 
            /*
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register your types, for instance using the scoped lifestyle:

            InitializeContainer(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            // Here your usual Web API configuration stuff.
            */
        }

        private static void InitializeContainer(Container container)
        {
            SimpleInjectorContainer.Initialize(container, Lifestyle.Singleton);
        }
    }
}
