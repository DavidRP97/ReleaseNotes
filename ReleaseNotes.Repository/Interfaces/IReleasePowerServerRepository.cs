using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IReleasePowerServerRepository : IGenericRepository<Release>
    {
        public Task<Release>InsertRelease(Release release);
        public Task<Module> InsertModule(Module module);
        public Task<Module> UpdateModules(Module module);
        public Task<bool> DeleteRange(long id);
        public Task<Release> SelectByIdWithInclude(long id);
        public Task<Module> SelectModuleById(long id);
        public Task<IEnumerable<Release>> GetAllIncludeModule();
    }
}
