using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(StorageFunction.Startup))]
namespace StorageFunction
{
    using global::StorageFunction.Controllers;
    using global::StorageFunction.Core.Interfaces;
    using global::StorageFunction.Infrastructure;
    using MediatR;
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<StorageController>();
            builder.Services.AddTransient<IConfiguration, Configuration>();
            builder.Services.AddTransient<IStorageProcessor, StorageProcessor>();
            builder.Services.AddTransient<IRequestDeserializer, RequestDeserializer>();
            builder.Services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            builder.Services.AddLogging();
        }
    }
}
