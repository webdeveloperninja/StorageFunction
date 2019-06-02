namespace StorageFunctionTests.Core.Entities
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StorageFunction.Core.Entities;

    [TestClass]
    public class StorageRequestTests
    {
        [TestMethod]
        public void GivenAnEmailRequest_WhenValid_ReturnsIsValidTrue()
        {
            string base64Decoded = "base64 encoded string";
            string base64Encoded;
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(base64Decoded);
            base64Encoded = System.Convert.ToBase64String(data);

            var sut = new StorageRequest
            {
                Base64Data = base64Encoded,
                ContentType = "Application/Json",
                ContainerName = "Container Name"
            };

            Assert.IsTrue(sut.IsValid());
        }

        [TestMethod]
        public void GivenAnEmailRequest_WhenNotValidBase64Data_ReturnsIsValidFalse()
        {
            var sut = new StorageRequest
            {
                Base64Data = "-- InValid Base 64 Data --",
                ContentType = "Application/Json",
                ContainerName = "Container Name"
            };

            Assert.IsFalse(sut.IsValid());
        }

        [TestMethod]
        public void GivenAnEmailRequest_WhenEmptyContentType_ReturnsIsValidFalse()
        {
            string base64Decoded = "base64 encoded string";
            string base64Encoded;
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(base64Decoded);
            base64Encoded = System.Convert.ToBase64String(data);

            var sut = new StorageRequest
            {
                Base64Data = base64Encoded,
                ContentType = "",
                ContainerName = "Container Name"
            };

            Assert.IsFalse(sut.IsValid());
        }

        [TestMethod]
        public void GivenAnEmailRequest_WhenEmptyContainerName_ReturnsIsValidFalse()
        {
            string base64Decoded = "base64 encoded string";
            string base64Encoded;
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(base64Decoded);
            base64Encoded = System.Convert.ToBase64String(data);

            var sut = new StorageRequest
            {
                Base64Data = base64Encoded,
                ContentType = "Application/Json",
                ContainerName = ""
            };

            Assert.IsFalse(sut.IsValid());
        }
    }
}
