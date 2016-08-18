using DevStore.Application.Base;
using DevStore.Domain;
using DevStore.Domain.Interfaces;
using System.Collections.Generic;

namespace DevStore.Application
{
    public class ProductApplication : ApplicationBase
    {
        private IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Register(Product product)
        {
            Begin();
            _productRepository.Add(product);
            Commit();
        }

        public void Deletar(Product product)
        {
            Begin();
            _productRepository.Delete(product);
            Commit();
        }

        public void Deletar(int id)
        {
            Begin();
            _productRepository.Delete(id);
            Commit();
        }

        public void Update(Product product)
        {
            Begin();
            _productRepository.Update(product);
            Commit();
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.Get();
        }

        public Product GetById(int id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetByCategory(int id)
        {
            return _productRepository.GetByCategory(id);
        }

        public IEnumerable<Product> GetByPrice(int id)
        {
            return _productRepository.GetByPrice(id);
        }
        
    }
}
