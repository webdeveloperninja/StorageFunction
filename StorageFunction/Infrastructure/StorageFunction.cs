namespace StorageFunction
{
    using global::StorageFunction.Controllers;
    using global::StorageFunction.Core.DTO;
    using global::StorageFunction.Core.Exceptions;
    using global::StorageFunction.Core.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

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
            try
            {
                var response = await _controller.Execute(request);
                return (ActionResult)new OkObjectResult(response.ResourceUri);
            }
            catch (BadRequestException)
            {
                return (ActionResult)new BadRequestObjectResult("Request not valid");
            }
        }
    }
}
