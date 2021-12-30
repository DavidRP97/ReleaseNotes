using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Call;
using ReleaseNotes.Service.Utils;
using System.Net.Http.Headers;

namespace ReleaseNotes.Service.Services
{
    public class CallService : ICallService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/v1/Call";
        public CallService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<CallViewModel>> FindAllCalls(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(BasePath);

            return await response.ReadContentAs<List<CallViewModel>>();
        }
    }
}
