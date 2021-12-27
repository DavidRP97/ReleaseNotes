using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class ReleasePowerServerRepository : GenericRepository<Release>, IReleasePowerServerRepository
    {
        private readonly NpgSqlContext _context;
        public ReleasePowerServerRepository(NpgSqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Release> InsertRelease(Release release)
        {
            await _context.Releases.AddRangeAsync(release);
            await Save();
            return release;
        }

        public async Task<bool> DeleteRange(long id)
        {
            var entity = await GetById(id);
            if (entity == null) return false;

            _context.Releases.RemoveRange(entity);
            await Save();

            return true;
        }

        public async Task<IEnumerable<Release>> GetAllIncludeModule()
        {
            return await _context.Releases.Include(x => x.Modules).ToListAsync();
        }

        public async Task<Release> SelectByIdWithInclude(long id) => await _context.Releases.Include(x => x.Modules).Where(y => y.ReleaseId == id).FirstOrDefaultAsync();
        public async Task<Module> SelectModuleById(long id) => await _context.Modules.FirstOrDefaultAsync(x => x.ModuleId == id);
        public async Task<Module> InsertModule(Module module)
        {
            await _context.AddAsync(module);
            await Save();
            return module;
        }
        public async Task<Module> UpdateModules(Module module)
        {
            var update = _context.Update(module);
            update.State = EntityState.Modified;
            await Save();
            return module;
        }
    }
}
