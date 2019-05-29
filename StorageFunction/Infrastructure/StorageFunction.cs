using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StorageFunction.Controllers;
using StorageFunction.Core.DTO;
using StorageFunction.Core.Interfaces;

namespace StorageFunction
{
    public class StorageFunction
    {
        private StorageController _controller;
        private IRequestDeserializer _deserializer;

        public StorageFunction(StorageController controller, IRequestDeserializer deserializer)
        {
            _controller = controller;
            _deserializer = deserializer;
        }

        [FunctionName("Storage")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var request = await _deserializer.Deserialize<StorageRequestDTO>(req);
            var response = await _controller.Execute(request);
            return (ActionResult)new OkObjectResult(response.ResourceUri);
        }
    }
}
