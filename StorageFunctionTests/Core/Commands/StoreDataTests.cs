namespace StorageFunctionTests.Core.Commands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StorageFunction.Core.Commands;
    using StorageFunction.Core.Entities;
    using StorageFunction.Core.Interfaces;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    [TestClass]
    public class StoreDataTests
    {
        [TestMethod]
        public async Task Handle_CallsStoreWithRequest_ReturnsResult()
        {
            var mockProcessor = new Mock<IStorageProcessor>();

            var sut = new StoreDataHandler(mockProcessor.Object);
        
            var request = new StorageRequest
            {
                Base64Data = "basedata",
                ContainerName = "containername",
                ContentType = "application/json"
            };

            var response = await sut.Handle(request, It.IsAny<CancellationToken>());

            Func<StorageRequest, bool> matches = r => r.Base64Data == request.Base64Data &&
                                                      r.ContentType == request.ContentType &&
                                                      r.ContainerName == request.ContainerName;

            mockProcessor.Verify(p => p.Store(It.Is<StorageRequest>(r => matches(r))));
        }
    }
}
