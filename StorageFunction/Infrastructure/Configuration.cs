using StorageFunction.Core.Interfaces;
using System;
using System.Text;

namespace StorageFunction.Infrastructure
{
    public class Configuration : IConfiguration 
    {
        public string AccessKey => Environment.GetEnvironmentVariable("Access_Key", EnvironmentVariableTarget.Process);
        public string AccountName => Environment.GetEnvironmentVariable("Account_Name", EnvironmentVariableTarget.Process);
    }
}
