using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IReleasePowerPDVRepository : IGenericRepository<ReleasePDV> 
    {
        Task<AttachmentDto> AddFiles(AttachmentDto attachmentDto);
        Task<ReleaseDto> InsertRelease(ReleaseDto release);
        Task<ModuleDto> InsertModule(ModuleDto module);
        Task<ModuleDto> UpdateModules(ModuleDto module);
        Task<ReleaseDto>UpdateReleases(ReleaseDto release);
        Task<ReleaseDto> SelectByIdWithInclude(long id);
        Task<ModuleDto> SelectModuleById(long id);
        Task<bool> DeleteRange(long id);
        Task<bool> DeleteModule(long id);
        Task<IEnumerable<ReleaseDto>> GetAllIncludeModule();
    }
}
