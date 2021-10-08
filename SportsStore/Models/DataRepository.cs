using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class DataRepository : IRepository
    {
        // private List<Product> data = new();
        private DataContext context;

        public DataRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Product> Products => context.Products.ToArray();

        public Product GetProduct(long key) => context.Products.Find(key);

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            p.Name = product.Name;
            p.Category = product.Category;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
            // context.Products.Update(product);
            context.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            context.Products.UpdateRange(products);
            context.SaveChanges();
        }
    }
}
