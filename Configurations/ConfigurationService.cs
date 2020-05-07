using System.IO;
using HospitalService.Abstractions;
using Microsoft.Extensions.Configuration;

namespace HospitalService.Configurations
{
    /// <summary>
    /// This service is responsible for retrieving the database connection string
    /// based on the Environment Variable and appsettings.json file 
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        private readonly IEnvironmentService _envService;
        public string CurrentDirectory { get; set; }

        public ConfigurationService(IEnvironmentService envService)
        {
            _envService = envService;
        }
        
        public IConfiguration GetConfiguration()
        {
            CurrentDirectory ??= Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_envService.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}