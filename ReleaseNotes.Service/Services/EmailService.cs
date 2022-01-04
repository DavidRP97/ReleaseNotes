using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Email;
using ReleaseNotes.Service.Utils;
using System.Net.Http.Headers;

namespace ReleaseNotes.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/v1/Email";
        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<SenderEmailConfigViewModel> FindEmail(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(BasePath);

            return await response.ReadContentAs<SenderEmailConfigViewModel>();
        }
    }
}
