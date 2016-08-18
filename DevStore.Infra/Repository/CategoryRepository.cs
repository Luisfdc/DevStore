using DevStore.Domain;
using DevStore.Domain.Interfaces;

namespace DevStore.Infra.Repository
{
    public class CategoryRepository: RepositoryBase<Category> , ICategoryRepository
    {
    }
}
