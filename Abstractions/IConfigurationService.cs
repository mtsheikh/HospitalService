using Microsoft.Extensions.Configuration;

namespace HospitalService.Abstractions
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}