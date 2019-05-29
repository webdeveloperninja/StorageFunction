namespace StorageFunction.Core.DTO
{
    public class StorageRequestDTO
    {
        public string Base64Data { get; set; }

        public string ContentType { get; set; }

        public string ContainerName { get; set; }
    }
}
