using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BusinessLayer;
using System.Net.Http;
using System.Net;
using Adapter;

namespace FunctionApp1
{
    public  class Function1
    {

       private readonly IQuery _service;
       public Function1(IQuery service)
        {
            _service = service;
           
        }
       
      
        [FunctionName("Function1")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string id = req.Query["id"];
            Adapter.HGV result = _service.test(id);
            log.LogInformation(" Id from query paramater--->{0}", id);
            HttpResponseMessage request = new HttpResponseMessage();
           
            if(result!=null)
            return  new OkObjectResult(result);
            else
            return new NotFoundObjectResult(result);

        }
    }
}
