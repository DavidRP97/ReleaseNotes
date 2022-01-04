using Microsoft.Extensions.DependencyInjection;
using ReleaseNotes.Repository.Interfaces;
using ReleaseNotes.Repository.Repositories;

namespace ReleaseNotes.IoC.Config
{
    public static class DependencyInjectionConfigRepository
    {
        public static void ConfigureDIRepository(this IServiceCollection services)
        {
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<ICallRepository, CallRepository>();
            services.AddScoped<IReleasePowerServerRepository, ReleasePowerServerRepository>();
            services.AddScoped<IReleasePowerPDVRepository, ReleasePowerPDVRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
        }
    }
}
