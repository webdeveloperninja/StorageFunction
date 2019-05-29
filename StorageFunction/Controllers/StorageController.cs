namespace StorageFunction.Controllers
{
    using global::StorageFunction.Core.DTO;
    using global::StorageFunction.Core.Entities;
    using MediatR;
    using System.Threading.Tasks;

    public class StorageController
    {
        private IMediator _mediator { get; set; }

        public StorageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<StorageResponseDTO> Execute(StorageRequestDTO requestDTO)
        {
            var request = new StorageRequest();
            request.Base64Image = requestDTO.Base64Image;

            return await _mediator.Send(request);
        }
    }
}
