using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IReleasePowerServerRepository : IGenericRepository<Release>
    {
        public Task<Release>InsertRange(Release release);
        public Task<bool> DeleteRange(long id);
        public Task<IEnumerable<Release>> GetAllIncludeModule();
    }
}
