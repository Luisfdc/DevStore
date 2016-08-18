using DevStore.Domain.Interfaces;
using DevStore.Infra.Repository;
using SimpleInjector;

namespace DevStore.Infra.IoC
{
    public static class SimpleInjectorContainer
    {
        public static void Initialize(Container container, Lifestyle lifestyle)
        {
            container.Register<ICategoryRepository, CategoryRepository>(lifestyle);
            container.Register<IUserRepository, UserRepository>(lifestyle);
            container.Register<IMessageRepository, MessageRepository>(lifestyle);
            container.Register<IProductRepository, ProductRepository>(lifestyle);
            container.Register<IUnitOfWork, UnitOfWork>(lifestyle);
        }
        
    }
}
