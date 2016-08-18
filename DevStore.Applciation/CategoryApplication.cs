using DevStore.Application.Base;
using DevStore.Domain;
using DevStore.Domain.Interfaces;
using System.Collections.Generic;

namespace DevStore.Application
{
    public class CategoryApplication : ApplicationBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Register(Category category)
        {
            Begin();
            _categoryRepository.Add(category);
            Commit();
        }

        public void Deletar(Category category)
        {
            Begin();
            _categoryRepository.Delete(category);
            Commit();
        }

        public void Deletar(int id)
        {
            Begin();
            _categoryRepository.Delete(id);
            Commit();
        }

        public void Update(Category category)
        {
            Begin();
            _categoryRepository.Update(category);
            Commit();
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.Get();
        }
        
        public Category GetById(int id)
        {
            return _categoryRepository.Get(id);
        }
    }
}
