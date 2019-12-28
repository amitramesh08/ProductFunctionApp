using System;
using System.Collections.Generic;
using System.Text;

namespace SB.ProductApi.Database.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Models.Product> GetProducts();
    }
}
