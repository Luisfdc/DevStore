using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DevStore.Domain;
using DevStore.Application;
using DevStore.Domain.Interfaces;

namespace DevStore.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApplication _productApplication;
        private readonly IProductRepository _productRepository;

        public ProductController(ProductApplication productApplication, IProductRepository productRepository)
        {
            _productApplication = productApplication;
            _productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = new List<Product>();

            products = _productRepository.Get().ToList(); ;
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product products;

            products = _productRepository.Get(id); ;

            return View(products);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult CreateProduct()
        {
            Product products = new Product();
            return View(products);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product products)
        {
            if (!ModelState.IsValid)
                return View("CreateProduct");

            try
            {
                if (products == null)
                    return View("CreateProduct");


                if (products.Id == 0)
                    _productApplication.Register(products);
                else
                    _productApplication.Update(products);


                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProduct");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product products;

            products = _productApplication.GetById(id);

            if (products == null)
                return RedirectToAction("Index");

            return View("CreateProduct", products);
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            _productApplication.Deletar(id);

            return RedirectToAction("Index");
        }


        

    }
}
