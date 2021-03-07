using Microsoft.Extensions.DependencyInjection;

namespace TAN.Core._3._1.Rest.Api.Swagger
{
    public interface IStartupCustom
    {
        void AddSwaggerConfigure(IServiceCollection services);
    }
}