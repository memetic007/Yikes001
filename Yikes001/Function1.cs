
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace Yikes001
{
    public static class Main
    {
        [FunctionName("YikesRCV")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;

            log.Info("C# HTTP trigger function processed a request.");
            
            

            string name = req.Query["name"];
            
            // string requestBody = new StreamReader(req.Body).ReadToEnd();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;
            
            return name != null
                ? (ActionResult)new OkObjectResult("VERSION 5 At: " + now.ToLocalTime() + $" Hello from YIKES001, {name}")
                : new BadRequestObjectResult("At: " + now.ToLocalTime() + " YIKES!  Please pass a name on the query string or in the request body");
        }

        [FunctionName("DirtyRCV")]
        public static IActionResult XRun([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;

            log.Info("C# HTTP trigger function processed a request.");



            string name = req.Query["name"];

            // string requestBody = new StreamReader(req.Body).ReadToEnd();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult("VERSION 5 FUCK FUCK At: " + now.ToLocalTime() + $" Hello from YIKES001, {name}")
                : new BadRequestObjectResult("At: " + now.ToLocalTime() + " YIKES!  Please pass a name on the query string or in the request body");
        }
    }
}
