using Microsoft.Extensions.DependencyInjection;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Services;

namespace ReleaseNotes.IoC.Config
{
    public static class DependecyInjectionConfigService
    {
        //PRODUCTION
        //public const string BaseAdress = "http://supercontrole.ddns.net:3370/";
        //DEVELOPMENT
        public const string BaseAdress = "https://localhost:7221";

        public static void ConfigDIService(this IServiceCollection Services)
        {
            Services.AddHttpClient<IReleasePowerServerService, ReleasePowerServerService>(c =>
                c.BaseAddress = new Uri(BaseAdress)
            );

            Services.AddHttpClient<IReleasePDVService, ReleasePDVService>(c =>
                c.BaseAddress = new Uri(BaseAdress)
            );

            Services.AddHttpClient<IFeedbackService, FeedbackService>(c =>
                c.BaseAddress = new Uri(BaseAdress)
            );

            Services.AddHttpClient<ICallService, CallService>(c =>
                c.BaseAddress = new Uri(BaseAdress)
            );
            Services.AddHttpClient<IEmailService, EmailService>(c =>
                c.BaseAddress = new Uri(BaseAdress)
            );

            Services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
