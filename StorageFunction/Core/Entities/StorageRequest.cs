namespace StorageFunction.Core.Entities
{
    using global::StorageFunction.Core.DTO;
    using MediatR;
    using System;

    public class StorageRequest : IRequest<StorageResponseDTO>
    {
        public string Base64Data { get; set; }

        public string ContentType { get; set; }

        public string ContainerName { get; set; }

        // TODO: More robust validation
        public bool IsValid()
        {
            return IsBase64(this.Base64Data) &&
                    !string.IsNullOrWhiteSpace(ContentType) &&
                    !string.IsNullOrWhiteSpace(ContainerName);
        }

        private bool IsBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception)
            {
                // No Op            
            }
            return false;
        }
    }
}
