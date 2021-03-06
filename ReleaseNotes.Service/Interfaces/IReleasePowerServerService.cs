using ReleaseNotes.Service.PowerServer.Models;

namespace ReleaseNotes.Service.Interfaces
{
    public  interface IReleasePowerServerService
    {
        Task<IEnumerable<ReleasePowerServerViewModel>> FindAllReleases();
        Task<ReleasePowerServerViewModel> FindReleaseById(long id, string token);
        Task<ModulePowerServerViewModel> FindModuleById(long? id, string token);
        Task<ReleasePowerServerViewModel> CreateRelease(ReleasePowerServerViewModel model, string token);
        Task<ModulePowerServerViewModel> CreateModule(ModulePowerServerViewModel model, string token);
        Task<ReleasePowerServerViewModel> UpdateRelease(ReleasePowerServerViewModel model, string token);
        Task<ModulePowerServerViewModel> UpdateModule(ModulePowerServerViewModel model, string token);
        Task<bool> DeleteReleaseById(long id, string token);
        Task<bool> DeleteModuleById(long id, string token);
    }
}
