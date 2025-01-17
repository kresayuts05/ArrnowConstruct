﻿using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ArrowConstructServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IConstructorService, ConstructorService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
