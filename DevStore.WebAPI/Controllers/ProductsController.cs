using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DevStore.Domain;
using DevStore.Domain.Interfaces;

namespace DevStore.WebAPI.Controllers
{
    [RoutePrefix("api/v1/public")]
    [EnableCors("*", "*", "*")]
    public class ProductsController : ApiController
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductsController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
                

        [Route("products")]
        public HttpResponseMessage Getproducts()
        {
            var result = _productRepository.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("products/{productsId}")]
        public HttpResponseMessage GetproductsbyId(int productsId)
        {
            var result = _productRepository.Get().FirstOrDefault(x => x.Id == productsId);
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("newproducts")]
        public HttpResponseMessage Getnewproducts()
        {
            var result = new Product();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("categories")]
        public HttpResponseMessage GetCategory()
        {
            var result = _categoryRepository.Get().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories/{categoryId}/products")]
        public HttpResponseMessage GetproductsByCategoryId(int categoryId)
        {
            var result = _productRepository.Get().Where(x => x.CategorYId == categoryId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProducts(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                if (product.Id > 0)
                    _productRepository.Update(product);
                else
                    _productRepository.Add(product);

                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto");
            }

        }


        [HttpDelete]
        [Route("products")]
        public HttpResponseMessage DeleteProducts(int productId)
        {
            if (productId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _categoryRepository.Delete(productId);

                return Request.CreateResponse(HttpStatusCode.OK, "Excluido com sucesso");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir produto");
            }

        }

        
    }
}