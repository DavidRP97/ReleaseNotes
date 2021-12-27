using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IReleasePowerPDVRepository : IGenericRepository<ReleasePDV> 
    {
        public Task<ReleasePDV> InsertRelease(ReleasePDV release);
        public Task<ModulePDV> InsertModule(ModulePDV module);
        public Task<ModulePDV> UpdateModules(ModulePDV module);
        public Task<ReleasePDV> SelectByIdWithInclude(long id);
        public Task<ModulePDV> SelectModuleById(long id);
        public Task<bool> DeleteRange(long id);
        public Task<bool> DeleteModule(long id);
        public Task<IEnumerable<ReleasePDV>> GetAllIncludeModule();
    }
}
