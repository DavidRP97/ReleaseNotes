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

        public async Task<CallViewModel> CreateCall(CallViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CallViewModel>();
            else throw new Exception("Somenthing wrong when calling API");
        }
        public async Task<CallViewModel> UpdateCall(CallViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CallViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CallViewModel> FindCallById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<CallViewModel>();
        }
    }
}
