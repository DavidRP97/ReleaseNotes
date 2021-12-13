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

        public async Task<Release> InsertRange(Release release)
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
            List<Module> modules = new List<Module>();
            List<Release> list = new List<Release>();
            await _context.Releases.ForEachAsync(list.Add);
            await _context.Modules.ForEachAsync(modules.Add);

            return list;
        }
    }
}
