using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Email;
using RestSharp;
using System.Net.Http;
using System.Text.Json;

namespace ReleaseNotes.Service.Services
{
    public class EmailSender : IEmailSender
    {
        
        private const string Url = "https://api.sendinblue.com/v3/smtp/email";
        public async Task<IRestResponse> SendEmail(NewCallOpenedEmail newCall, string apiKey)
        {
            var client = new RestClient(Url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("api-key", $"{apiKey}");
            request.AddHeader("content-type", "application/json");

            var serialize = JsonSerializer.Serialize(newCall);
            
            request.AddParameter("application/json", serialize, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}
