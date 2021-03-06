using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Nano35.Contracts;
using Nano35.Contracts.Storage.Artifacts;

namespace Nano35.RepairOrders.Api.Configurations
{
    public class MassTransitConfiguration : 
        IConfigurationOfService
    {
        public void AddToServices(
            IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {   
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri($"{ContractBase.RabbitMqLocation}/"), h =>
                    {
                        h.Username(ContractBase.RabbitMqUsername);
                        h.Password(ContractBase.RabbitMqPassword);
                    });
                }));
                x.AddRequestClient<IGetAllArticlesRequestContract>(
                    new Uri($"{ContractBase.RabbitMqLocation}/IGetAllArticlesRequestContract"));
            });
            services.AddMassTransitHostedService();
        }
    }
}