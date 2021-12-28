using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class ReleasePowerPDVRepository : GenericRepository<ReleasePDV>, IReleasePowerPDVRepository
    {
        private readonly NpgSqlContext _context;
        private IMapper _mapper;
        public ReleasePowerPDVRepository(NpgSqlContext context, IMapper mapper) : base(context)
        {
            _context = context; 
            _mapper = mapper;   
        }

        public async Task<bool> DeleteRange(long id)
        {
            var entity = _context.ReleasePDVs.FindAsync(id);

            if (entity == null) return false;

            _context.RemoveRange(entity);

            await Save();

            return true;
        }

        public async Task<IEnumerable<ReleaseDto>> GetAllIncludeModule()
        {
            List<ReleasePDV> releases = await _context.ReleasePDVs.Include(x => x.Modules).ToListAsync();

            return _mapper.Map<List<ReleaseDto>>(releases);
        }

        public async Task<ReleaseDto> InsertRelease(ReleaseDto release)
        {
            ReleasePDV releasePDV = _mapper.Map<ReleasePDV>(release);  
            await _context.AddAsync(releasePDV);
            await Save();
            return _mapper.Map<ReleaseDto>(releasePDV);
        }
        public async Task<ModuleDto> InsertModule(ModuleDto module)
        {
            ModulePDV modulePDV = _mapper.Map<ModulePDV>(module);
            await _context.AddAsync(modulePDV);
            await Save();
            return _mapper.Map<ModuleDto>(modulePDV);
        }
        public async Task<ModuleDto> UpdateModules(ModuleDto module)
        {
            ModulePDV modulePDV = _mapper.Map<ModulePDV>(module);

            _context.Update(modulePDV);
            await Save();

            return _mapper.Map<ModuleDto>(modulePDV);
        }
        public async Task<ReleaseDto> UpdateReleases(ReleaseDto release)
        {
            ReleasePDV releasePdv = _mapper.Map<ReleasePDV>(release);

            _context.Update(releasePdv);
            await Save();

            return _mapper.Map<ReleaseDto>(releasePdv);
        }

        public async Task<ReleaseDto> SelectByIdWithInclude(long id)
        {
            ReleasePDV releasePDV = await _context.ReleasePDVs.Include(x => x.Modules).Where(y => y.ReleaseId == id).FirstOrDefaultAsync();

            return _mapper.Map<ReleaseDto>(releasePDV);
        } 
        public async Task<ModuleDto> SelectModuleById(long id)
        {
            ModulePDV modulePDV = await _context.ModulePDVs.FirstOrDefaultAsync(x => x.ModuleId == id);

            return _mapper.Map<ModuleDto>(modulePDV);
        }

        public async Task<bool> DeleteModule(long id)
        {
            var entity = await SelectModuleById(id);

            if (entity == null) return false;

            _context.Remove(entity);

            await Save();

            return true;
        }
    }
}
