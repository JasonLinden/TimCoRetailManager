using System.Collections.Generic;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        [HttpGet]
        public IEnumerable<ProductEntity> Get()
        {

            ProductRepository productRepository = new ProductRepository();

            List<ProductEntity> products = productRepository.GetProducts();

            return products;
        }
    }
}
