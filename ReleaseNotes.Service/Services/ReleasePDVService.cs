using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.PDV;
using ReleaseNotes.Service.Utils;
using System.Net.Http.Headers;

namespace ReleaseNotes.Service.Services
{
    public class ReleasePDVService : IReleasePDVService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/v1/ReleasePDV";

        public ReleasePDVService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ReleasePDVViewModel> CreateRelease(ReleasePDVViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ReleasePDVViewModel>();
            else throw new Exception("Somenthing wrong when calling API");
        }

        public async Task<bool> DeleteReleaseById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<ReleasePDVViewModel>> FindAllReleases()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ReleasePDVViewModel>>();
        }

        public async Task<ReleasePDVViewModel> FindReleaseById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ReleasePDVViewModel>();
        }

        public async Task<ReleasePDVViewModel> UpdateRelease(ReleasePDVViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ReleasePDVViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
