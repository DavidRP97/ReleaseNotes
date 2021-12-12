using Microsoft.Extensions.DependencyInjection;
using ReleaseNotes.Repository.Interfaces.ReleasesPowerServer;
using ReleaseNotes.Repository.Repositories.ReleasesPowerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNotes.IoC.Config.Repository
{
    public static class DependencyInjectionConfigRepository
    {
        public static void ConfigureDIRepository(this IServiceCollection services)
        {
            services.AddScoped<IReleasePowerServerRepository, ReleasePowerServerRepository>();
        }
    }
}
