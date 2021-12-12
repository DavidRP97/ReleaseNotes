using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.PowerServer.Models;
using ReleaseNotes.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNotes.Service.Services
{
    public class ReleasePowerServerService : IRealesePowerServerService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/v1/ReleasePowerServer";
        public ReleasePowerServerService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));   
        }
        public async Task<ReleasePowerServerViewModel> CreateRelease(ReleasePowerServerViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ReleasePowerServerViewModel>();
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
        public async Task<ReleasePowerServerViewModel> UpdateRelease(ReleasePowerServerViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ReleasePowerServerViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<ReleasePowerServerViewModel>> FindAllReleases()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ReleasePowerServerViewModel>>();
        }

        public async Task<ReleasePowerServerViewModel> FindReleaseById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ReleasePowerServerViewModel>();
        }

    }
}
