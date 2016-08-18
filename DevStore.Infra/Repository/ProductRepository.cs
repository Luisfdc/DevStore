using DevStore.Domain;
using DevStore.Domain.Interfaces;
using DevStore.Infra.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace DevStore.Infra.Repository
{
    public class ProductRepository : RepositoryBase<Product> , IProductRepository
    {

        private readonly DevStoreDataContexts _devStoreDataContexts;

        public ProductRepository()
        {
            _devStoreDataContexts = new DevStoreDataContexts();
        }
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            return _devStoreDataContexts.Product.Where(x => x.CategorYId == categoryId);
        }

        public IEnumerable<Product> GetByPrice(decimal price)
        {
            return _devStoreDataContexts.Product.Where(x => x.Price == price);
        }
    }
}
