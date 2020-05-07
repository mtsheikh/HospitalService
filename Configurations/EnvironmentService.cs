using System;
using HospitalService.Abstractions;

namespace HospitalService.Configurations
{
    /// <summary>
    ///  This service is responsible for getting and setting an environment variable
    /// </summary>
    public class EnvironmentService : IEnvironmentService
    {     
        public EnvironmentService() =>
            EnvironmentName = Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.AspnetCoreEnvironment)
                              ?? Constants.Environments.Production;
        public string EnvironmentName { get; set; }
    }
}