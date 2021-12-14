﻿using Microsoft.Extensions.DependencyInjection;
using ReleaseNotes.Repository.Interfaces;
using ReleaseNotes.Repository.Repositories;

namespace ReleaseNotes.IoC.Config.Repository
{
    public static class DependencyInjectionConfigRepository
    {
        public static void ConfigureDIRepository(this IServiceCollection services)
        {
            services.AddScoped<IReleasePowerServerRepository, ReleasePowerServerRepository>();
            services.AddScoped<IReleasePowerPDVRepository, ReleasePowerPDVRepository>();
        }
    }
}