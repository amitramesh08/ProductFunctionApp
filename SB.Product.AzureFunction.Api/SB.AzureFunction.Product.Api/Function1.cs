using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SB.ProductApi.Database.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SB.AzureFunction.Product.Api
{
    public class Function1
    {
        private readonly IProductRepository productRepository;
        public Function1(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [FunctionName("Produsts")]
        public  async Task<IActionResult> GetProducts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = "products")] HttpRequest req,
            ILogger log)
        {
            var prod =  productRepository.GetProducts();
            var products = new List<SB.ProductApi.Database.Models.Product>(prod);
            log.LogInformation("C# HTTP trigger function processed a request.");

            return (ActionResult)new OkObjectResult(products);
        }

        [FunctionName("GetProduct")]
        public async Task<IActionResult> GetProductById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products/{productId}")] HttpRequest req,
            ILogger log, string productId)
        {
            try
            {
                var prod = productRepository.GetProducts().Single(x => x.ProductId == int.Parse(productId));
                log.LogInformation("C# HTTP trigger function processed a request.");
                return (ActionResult)new OkObjectResult(prod);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
