using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class ReleasePowerPDVRepository : GenericRepository<ReleasePDV>, IReleasePowerPDVRepository
    {
        private readonly NpgSqlContext _context;
        public ReleasePowerPDVRepository(NpgSqlContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<bool> DeleteRange(long id)
        {
            var entity = GetById(id);
            if (entity == null) return false;

            _context.RemoveRange(entity);
            await Save();

            return true;
        }

        public async Task<IEnumerable<ReleasePDV>> GetAllIncludeModule()
        {
            return await _context.ReleasePDVs.Include(x => x.Modules).ToListAsync();
        }

        public async Task<ReleasePDV> InsertRange(ReleasePDV release)
        {
            await _context.AddRangeAsync(release);
            await Save();
            return release;
        }

        public async Task<ReleasePDV> SelectByIdWithInclude(long id) => await _context.ReleasePDVs.Include(x => x.Modules).Where(y => y.ReleaseId == id).FirstOrDefaultAsync();
    }
}
