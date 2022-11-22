using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data.Common;

namespace ArrnowConstruct.Extensions
{
    public static class ArrowConstructServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IRequestService, RequestService>();
            //services.AddScoped<IAgentService, AgentService>();

            return services;
        }
    }
}
