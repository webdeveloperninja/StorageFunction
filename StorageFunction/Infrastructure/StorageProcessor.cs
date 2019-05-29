namespace StorageFunction.Infrastructure
{
    using global::StorageFunction.Core.DTO;
    using global::StorageFunction.Core.Entities;
    using global::StorageFunction.Core.Interfaces;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    internal class StorageProcessor : IStorageProcessor
    {
        private IConfiguration _configuration;

        public StorageProcessor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<StorageResponseDTO> Store(StorageRequest request)
        {
            CloudStorageAccount storageAccount = GetStorageAccount();

            CloudBlobContainer container = await GetContainer(storageAccount);

            CloudBlockBlob blob = CreateBlob(container);

            byte[] dataToUpload = CreateDataToUpload(request);

            return await UploadToStorage(blob, dataToUpload);
        }

        private static async Task<StorageResponseDTO> UploadToStorage(CloudBlockBlob blob, byte[] dataToUpload)
        {
            using (Stream stream = new MemoryStream(dataToUpload))
            {
                await blob.UploadFromStreamAsync(stream);

                return new StorageResponseDTO
                {
                    ResourceUri = blob.Uri.AbsoluteUri
                };
            }
        }

        private static byte[] CreateDataToUpload(StorageRequest request)
        {
            return Convert.FromBase64String(request.Base64Image);
        }

        private static CloudBlockBlob CreateBlob(CloudBlobContainer container)
        {
            var name = Guid.NewGuid().ToString("n");
            var blob = container.GetBlockBlobReference(name);

            blob.Properties.ContentType = "image/jpeg";

            return blob;
        }

        private async Task<CloudBlobContainer> GetContainer(CloudStorageAccount storageAccount)
        {
            var client = storageAccount.CreateCloudBlobClient();
            var container = client.GetContainerReference(_configuration.ContainerName);

            await container.CreateIfNotExistsAsync();

            return container;
        }

        private CloudStorageAccount GetStorageAccount()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=" + _configuration.AccountName + ";AccountKey=" + _configuration.AccessKey + ";EndpointSuffix=core.windows.net";

            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
