using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ProductController;
using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private IProductController productControllerRepo;
        public ProductController(IProductController _productControllerRepo)
        {
            productControllerRepo = _productControllerRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product_DTO>> GetProducts()
        {
            return productControllerRepo.GetProducts().
                Select(x => new Product_DTO {Id=x.Id, Name = x.Name, Number = x.Number, Quantity = x.Quantity, Description = x.Description, Price = x.Price }).ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Product_DTO> GetProduct(Guid id)
        {
         var product = productControllerRepo.GetProduct(id);
            if (product == null)
                return NotFound();
            var product_dto = new Product_DTO {Id=product.Id, Name = product.Name, Number = product.Number, Quantity = product.Quantity, Description = product.Description, Price = product.Price };
            return product_dto;
        }
        [HttpPost]
        public ActionResult CreateProduct(Create_Update_Product_DTO product)
        {
            var id = Guid.NewGuid();
            var _product = new Product();
            _product.Id = Guid.NewGuid();
            _product.Name = product.Name;
            _product.Number = product.Number;
            _product.Quantity = product.Quantity;
            _product.Description = product.Description;
            _product.Price = product.Price;
            id = productControllerRepo.CreateProduct(_product);
            return Ok();
        }
        [HttpPost("{id}")]
        public ActionResult UpdateProduct(Guid id, Create_Update_Product_DTO product)
        {
            var _product = productControllerRepo.GetProduct(id);
            if (_product == null)
                return NotFound();
            _product.Name = product.Name;
            _product.Number = product.Number;
            _product.Quantity = product.Quantity;
            _product.Description = product.Description;
            _product.Price = product.Price;
            productControllerRepo.UpdateProduct(id, _product);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var _product = productControllerRepo.GetProduct(id);
            if (_product==null)
                return NotFound();
            productControllerRepo.DeleteProduct(id);
            return Ok();
        }
    }
}
