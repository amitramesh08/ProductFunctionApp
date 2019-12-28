using System;
using System.Collections.Generic;
using System.Text;
using SB.ProductApi.Database.Models;

namespace SB.ProductApi.Database.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDatabaseContext productDatabaseContext;

        public ProductRepository(ProductDatabaseContext productDatabaseContext)
        {
            this.productDatabaseContext = productDatabaseContext;
        }
        public IEnumerable<Product> GetProducts()
        {
            return productDatabaseContext.Products;
        }
    }
}
