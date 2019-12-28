using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.ProductApi.Database
{
    public class ProductDatabaseContext : DbContext
    {
        public ProductDatabaseContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Models.Product> Products { get; set; }
    }
}
