using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Feedback;
using ReleaseNotes.Service.Utils;
using System.Net.Http.Headers;

namespace ReleaseNotes.Service.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/v1/Feedback";
        public FeedbackService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<FeedbackViewModel>> FindAllFeedbacks(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(BasePath);

            return await response.ReadContentAs<List<FeedbackViewModel>>();
        }

        public async Task<FeedbackViewModel> CreateFeedback(FeedbackViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<FeedbackViewModel>();
            else throw new Exception("Somenthing wrong when calling API");
        }

        public async Task<bool> DeleteFeedback(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<FeedbackViewModel> FindFeedbackById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<FeedbackViewModel>();
        }
    }
}
