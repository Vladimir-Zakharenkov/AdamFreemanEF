using System.Collections.Generic;

namespace SportsStore.Models
{
    public class DataRepository : IRepository
    {
        private List<Product> data = new();

        public IEnumerable<Product> Products => data;

        public void AddProduct(Product product) => data.Add(product);
    }
}
