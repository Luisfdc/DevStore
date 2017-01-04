using DevStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DevStore.WebAPI.Controllers
{
    [RoutePrefix("api/v1/public")]
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [Route("categories")]
        public HttpResponseMessage GetCategory()
        {
            var result = _categoryRepository.Get().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
