using System.Collections.Generic;

namespace DevStore.Domain.Interfaces
{
    public interface IProductRepository: IRepositoryBase<Product>
    {
        IEnumerable<Product> GetByPrice(decimal price);
        IEnumerable<Product> GetByCategory(int categoryId);
    }
}
