namespace StorageFunction.Controllers
{
    using global::StorageFunction.Core.DTO;
    using global::StorageFunction.Core.Entities;
    using global::StorageFunction.Core.Exceptions;
    using MediatR;
    using System;
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
            var request = new StorageRequest
            {
                Base64Data = requestDTO.Base64Data,
                ContentType = requestDTO.ContentType,
                ContainerName = requestDTO.ContainerName
            };

            if (!request.IsValid())
            {
                throw new BadRequestException();
            }

            return await _mediator.Send(request);
        }


    }
}
