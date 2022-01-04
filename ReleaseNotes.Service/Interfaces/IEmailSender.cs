using ReleaseNotes.Service.Models.Email;
using RestSharp;

namespace ReleaseNotes.Service.Interfaces
{
    public interface IEmailSender
    {
        Task<IRestResponse> SendEmail(NewCallOpenedEmail newCall, string apiKey);
    }
}
