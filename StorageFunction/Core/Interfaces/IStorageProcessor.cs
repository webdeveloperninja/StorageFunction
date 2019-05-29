using StorageFunction.Core.DTO;
using StorageFunction.Core.Entities;
using System.Threading.Tasks;

namespace StorageFunction.Core.Interfaces
{
    public interface IStorageProcessor
    {
        Task<StorageResponseDTO> Store(StorageRequest request);
    }
}
