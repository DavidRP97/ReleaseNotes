using ReleaseNotes.Service.Models.PDV;

namespace ReleaseNotes.Service.Interfaces
{
    public interface IReleasePDVService
    {
        Task<IEnumerable<ReleasePDVViewModel>> FindAllReleases();
        Task<ReleasePDVViewModel> FindReleaseById(long id, string token);
        Task<ModulePDVViewModel> FindModuleById(long? id, string token);
        Task<ReleasePDVViewModel> CreateRelease(ReleasePDVViewModel model, string token);
        Task<ModulePDVViewModel> CreateModule(ModulePDVViewModel model, string token);
        Task<ReleasePDVViewModel> UpdateRelease(ReleasePDVViewModel model, string token);
        Task<ModulePDVViewModel> UpdateModule(ModulePDVViewModel model, string token);
        Task<bool> DeleteReleaseById(long id, string token);
        Task<bool> DeleteModuleById(long id, string token);
    }
}
