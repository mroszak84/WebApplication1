using WebApplication1.ProductController;

namespace WebApplication1.Repo
{
    public interface IProductController
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProduct(Guid id);
        public Guid CreateProduct(Product product);
        public void UpdateProduct(Guid id, Product product);
        public void DeleteProduct(Guid id);
        
    }
}
