using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SB.ProductApi.Database.Repository;
using SB.ProductApi.Database.Models;
using System.Collections.Generic;

namespace SB.AzureFunction.Product.Api
{
    public class Function1
    {
        private readonly IProductRepository productRepository;
        public Function1(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            //var p = productRepository.GetProducts();
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
    }
}
