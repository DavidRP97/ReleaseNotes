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
            var entity = _context.ReleasePDVs.FindAsync(id);

            if (entity == null) return false;

            _context.RemoveRange(entity);

            await Save();

            return true;
        }

        public async Task<IEnumerable<ReleasePDV>> GetAllIncludeModule()
        {
            return await _context.ReleasePDVs.Include(x => x.Modules).ToListAsync();
        }

        public async Task<ReleasePDV> InsertRelease(ReleasePDV release)
        {
            await _context.AddAsync(release);
            await Save();
            return release;
        }
        public async Task<ModulePDV> InsertModule(ModulePDV module)
        {
            await _context.AddAsync(module);
            await Save();
            return module;
        }

        public async Task<ReleasePDV> SelectByIdWithInclude(long id) => await _context.ReleasePDVs.Include(x => x.Modules).Where(y => y.ReleaseId == id).FirstOrDefaultAsync();
    }
}
