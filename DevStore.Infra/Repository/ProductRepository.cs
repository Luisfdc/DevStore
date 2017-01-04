using DevStore.Domain;
using DevStore.Domain.Interfaces;
using DevStore.Infra.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DevStore.Infra.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        private readonly DevStoreDataContexts _devStoreDataContexts;

        public ProductRepository()
        {
            _devStoreDataContexts = new DevStoreDataContexts();
        }
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            using (_devStoreDataContexts)
            {
                return _devStoreDataContexts.Product.Where(x => x.CategorYId == categoryId);
            }
        }

        public IEnumerable<Product> GetByPrice(decimal price)
        {
            using (_devStoreDataContexts)
            {
                return _devStoreDataContexts.Product.Where(x => x.Price == price);
            }
        }

        public IEnumerable<Product> GetEndCategory()
        {
            using (_devStoreDataContexts)
            {
                return _devStoreDataContexts.Product.Include("Category").ToList(); ;
            }
        }
    }
}
