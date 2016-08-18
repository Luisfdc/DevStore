using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DevStore.Domain;
using DevStore.Application;
using DevStore.Domain.Interfaces;

namespace DevStore.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryApplication _categoryApplication;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(CategoryApplication categoryApplication, ICategoryRepository categoryRepository)
        {
            _categoryApplication = categoryApplication;
            _categoryRepository = categoryRepository;
        }
        

        // GET: Category
        public ActionResult Index()
        {
            List<Category> category = GetCategory();

            return View(category);
        }

        public List<Category> GetCategory()
        {
            return _categoryApplication.GetAll().ToList();
        }

    }
}