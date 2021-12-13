using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IReleasePowerPDVRepository : IGenericRepository<ReleasePDV> 
    {
        public Task<ReleasePDV> InsertRange(ReleasePDV release);
        public Task<bool> DeleteRange(long id);
        public Task<IEnumerable<ReleasePDV>> GetAllIncludeModule();
    }
}
