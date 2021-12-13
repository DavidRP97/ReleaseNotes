using ReleaseNotes.Service.Models.PDV;

namespace ReleaseNotes.Service.Interfaces
{
    public interface IReleasePDVService
    {
        Task<IEnumerable<ReleasePDVViewModel>> FindAllReleases();
        Task<ReleasePDVViewModel> FindReleaseById(long id, string token);
        Task<ReleasePDVViewModel> CreateRelease(ReleasePDVViewModel model, string token);
        Task<ReleasePDVViewModel> UpdateRelease(ReleasePDVViewModel model, string token);
        Task<bool> DeleteReleaseById(long id, string token);
    }
}
