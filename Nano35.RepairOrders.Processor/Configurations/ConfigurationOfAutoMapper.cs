using Microsoft.Extensions.DependencyInjection;
using Nano35.Contracts;

namespace Nano35.RepairOrders.Processor.Configurations
{
    public class AutoMapperConfiguration : 
        IConfigurationOfService
    {
        public void AddToServices(
            IServiceCollection services)
        {
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new ArticlesCategoryAutoMapperProfile());
            //    mc.AddProfile(new StorageItemConditionAutoMapperProfile());
            //    mc.AddProfile(new ArticleAutoMapperProfile());
            //    mc.AddProfile(new StorageItemAutoMapperProfile());
            //    mc.AddProfile(new ComingAutoMapperProfile());
            //    mc.AddProfile(new ComingDetailAutoMapperProfile());
            //});
            //var mapper = mapperConfig.CreateMapper();
            //MappingPipe.Mapper = mapper;
            //services.AddSingleton(mapper);
        }
    }
}