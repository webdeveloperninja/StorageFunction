using MediatR;
using StorageFunction.Core.DTO;
using StorageFunction.Core.Entities;
using StorageFunction.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StorageFunction.Core.Commands
{
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
