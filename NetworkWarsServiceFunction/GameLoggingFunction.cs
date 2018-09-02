using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace NetworkWarsServiceFunction
{
    public static class GameLoggingFunction
    {
        
        [FunctionName("GameLog")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            try
            {
                log.Info("C# HTTP trigger function processed a request.");

                // parse query parameter
                string data = await req.Content.ReadAsStringAsync();

                log.Info(data);

                await StoreToBlob(data, log);

                return req.CreateResponse(HttpStatusCode.OK, "");
            }
            catch (Exception ex)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private async static Task StoreToBlob(string data, TraceWriter log)
        {
            try
            {
                string storageConnectionString = ConfigurationManager.AppSettings["AzureWebJobsStorage"];

                CloudStorageAccount storageAccount;
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);

                CloudBlobClient client;
                CloudBlobContainer container;

                client = storageAccount.CreateCloudBlobClient();
                string suffix = DateTime.UtcNow.ToString("yyyy-MM");


                container = client.GetContainerReference("gamedata-" + suffix);
                await container.CreateIfNotExistsAsync();

                CloudBlockBlob blob;
                string name = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-");

                name += Guid.NewGuid().ToString("n");
                blob = container.GetBlockBlobReference(name);
                blob.Properties.ContentType = "application/json";

                using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                {
                    await blob.UploadFromStreamAsync(stream);
                }
            } catch (Exception ex)
            {
                log.Error("Error saving blob", ex);
            }
        }
    }
}
