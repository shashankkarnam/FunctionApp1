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
using Adapter;
using System.Net.Http;
using System.Net;
using System.Configuration;

namespace FunctionApp1
{
    public class Function1
    {

        private readonly IQuery _service;
        public Function1(IQuery service)
        {
            _service = service;

        }


        [FunctionName("HGVTestFunction")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Function Started......");

            try
            {
                //Get id from http url
                string id = req.Query["id"];

                //call to method  in BusinessLayer
                var result = await _service.test(id);
                log.LogInformation(" Id from query paramater--->{0}", id);

                if (result != null)
                    //returns result with status code
                    return new OkObjectResult(result);
                else
                    return new NotFoundObjectResult(result);
            }
            catch (Exception e)
            {
                log.LogInformation(" Exception-->{0}", e);
                throw new Exception();
            }

        }
    }
}
