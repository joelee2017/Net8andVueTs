using Microsoft.AspNetCore.Mvc;
using static Net8andVueTs.Server.Controllers.ProductController;

namespace Net8andVueTs.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> productList;
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public ProductController()
        {
            if(productList == null)
            {
                productList = new List<Product>() {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" } };
            }
        }

        // GET: api/Product
        [HttpGet("GetProducts")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(productList);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var p = productList.Find(product => product.Id == id);
            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // POST: api/Product
        [HttpPost("PostProduct")]
        public ActionResult PostProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            if (product != null)
            {
                product.Id = productList.LastOrDefault().Id + 1;
            }
            productList.Add(product);
            return Ok();
        }

        // PUT: api/Product/5
        [HttpPut("PutProduct")]
        public ActionResult PutProduct(Product product)
        {
            var index = productList.FindIndex(p => p.Id == product.Id);
            if (index == -1)
            {
                return NotFound("Product not found.");
            }
            productList[index] = product;
            return Ok();
        }

        // DELETE: api/Product/5
        [HttpPost("DeleteProduct")]
        public ActionResult DeleteProduct([FromBody] int id)
        {
            var product = productList.Find(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            productList.Remove(product);

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return productList.Any(e => e.Id == id);
        }
    }
}
