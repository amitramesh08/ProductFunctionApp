using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using SB.ProductApi.Database.Repository;
using SB.ProductApi.Database.Models;
using SB.ProductApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(SB.AzureFunction.Product.Api.Startup))]
namespace SB.AzureFunction.Product.Api
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            
            IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

            string productConnectionString= config.GetConnectionString("ProductDatabase");

            builder.Services.AddDbContext<ProductDatabaseContext>(option =>
            {
                SqlServerDbContextOptionsExtensions.UseSqlServer(option, productConnectionString);
            });
            
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
