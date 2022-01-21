using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IReleasePowerServerRepository : IGenericRepository<ReleasePowerServer>
    {
        Task<AttachmentDto> AddFiles(AttachmentDto attachmentDto);
        public Task<ReleaseDto> InsertRelease(ReleaseDto release);
        public Task<ModuleDto> InsertModule(ModuleDto module);
        public Task<ModuleDto> UpdateModules(ModuleDto module);
        public Task<ReleaseDto> UpdateReleases(ReleaseDto module);
        public Task<bool> DeleteRange(long id);
        public Task<bool> DeleteModule(long id);
        public Task<ReleaseDto> SelectByIdWithInclude(long id);
        public Task<ModuleDto> SelectModuleById(long id);
        public Task<IEnumerable<ReleaseDto>> GetAllIncludeModule();
    }
}
