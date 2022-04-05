using WebApplication1.ProductController;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Repo
{
    public class InMemProductRepo : IProductController
    {
 
        private List<Product> _products = new List<Product>();
        private List<Product> Read_Products()
        {
            _products.Clear();
            string fileName = "Products.json";
             string jsonString = File.ReadAllText(fileName);
           // Product product_ = JsonSerializer.Deserialize<Product>(jsonString)!;
            _products = JsonSerializer.Deserialize<List<Product>>(jsonString)!;
           //  _products.Add(product_);
            
               
               // Product product = JsonSerializer.Deserialize<Product>(jsonString)!;
               // _products.Add(product);
            
            return _products;
        }
        
        public InMemProductRepo()
        {
          //  Read_Products();
        }
        private void Save_Date()
        {
            string fileName = "Products.json";
            string jsonString = JsonSerializer.Serialize(_products);
            File.WriteAllText(fileName, jsonString);
        }
        public Guid CreateProduct(Product product)
        {
            _products.Add(product);
            Save_Date();
            return product.Id;
        }

        public void DeleteProduct(Guid id)
        {
            var product_index = _products.FindIndex(x => x.Id == id);
            if (product_index > -1)
                _products.RemoveAt(product_index);
            Save_Date();
        }

        public Product GetProduct(Guid id)
        {
          var product = _products.Where(x => x.Id == id).FirstOrDefault();
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Read_Products();
            //return _products;

        }

        public void UpdateProduct(Guid id, Product product)
        {
            var product_index = _products.FindIndex(x => x.Id == id);
            if (product_index > -1)
                _products[product_index] = product;
            Save_Date();
        }
    }
}
