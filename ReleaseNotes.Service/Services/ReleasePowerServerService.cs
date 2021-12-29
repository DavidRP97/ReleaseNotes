using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.PowerServer.Models;
using ReleaseNotes.Service.Utils;
using System.Net.Http.Headers;

namespace ReleaseNotes.Service.Services
{
    public class ReleasePowerServerService : IReleasePowerServerService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/v1/ReleasePowerServer";
        private const string BasePathFindModule = "api/v1/ReleasePowerServer/Module";
        private const string BasePathModules = "api/v1/ReleasePowerServer/CreateModules";
        private const string BasePathUpdateModules = "api/v1/ReleasePowerServer/UpdateModules";
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

        public async Task<ModulePowerServerViewModel> CreateModule(ModulePowerServerViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePathModules, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ModulePowerServerViewModel>();
            else throw new Exception("Somenthing wrong when calling API");
        }

        public async Task<ModulePowerServerViewModel> UpdateModule(ModulePowerServerViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson(BasePathUpdateModules, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ModulePowerServerViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<ModulePowerServerViewModel> FindModuleById(long? id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePathFindModule}/{id}");
            return await response.ReadContentAs<ModulePowerServerViewModel>();
        }

        public async Task<bool> DeleteModuleById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePathFindModule}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
