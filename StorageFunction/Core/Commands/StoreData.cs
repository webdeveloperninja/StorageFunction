namespace StorageFunction.Core.Commands
{
    using global::StorageFunction.Core.DTO;
    using global::StorageFunction.Core.Entities;
    using global::StorageFunction.Core.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class StoreDataHandler : IRequestHandler<StorageRequest, StorageResponseDTO>
    {
        private IStorageProcessor _storageProcessor { get; set; }

        public StoreDataHandler(IStorageProcessor storageProcessor)
        {
            _storageProcessor = storageProcessor;
        }

        public async Task<StorageResponseDTO> Handle(StorageRequest request, CancellationToken cancellationToken)
        {
            return await _storageProcessor.Store(request);
        }
    }
}
