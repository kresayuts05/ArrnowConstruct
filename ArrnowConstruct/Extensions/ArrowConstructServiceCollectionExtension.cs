namespace ArrnowConstruct.Extensions
{
    public static class ArrowConstructServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, Repository>();
            //services.AddScoped<IHouseService, HouseService>();
            //services.AddScoped<IAgentService, AgentService>();

            return services;
        }
    }
}
