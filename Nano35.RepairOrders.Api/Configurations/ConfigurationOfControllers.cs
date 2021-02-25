using Microsoft.Extensions.DependencyInjection;
using Nano35.Contracts;

namespace Nano35.RepairOrders.Api.Configurations
{
    public class ConfigurationOfControllers : 
        IConfigurationOfService
    {
        public void AddToServices(
            IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}