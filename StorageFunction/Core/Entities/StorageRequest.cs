namespace StorageFunction.Core.Entities
{
    using global::StorageFunction.Core.DTO;
    using MediatR;

    public class StorageRequest : IRequest<StorageResponseDTO>
    {
        public string Base64Image { get; set; }
    }
}
