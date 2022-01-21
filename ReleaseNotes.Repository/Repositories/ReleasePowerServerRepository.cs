using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class ReleasePowerServerRepository : GenericRepository<ReleasePowerServer>, IReleasePowerServerRepository
    {
        private readonly NpgSqlContext _context;
        private IMapper _mapper;
        public ReleasePowerServerRepository(NpgSqlContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<ReleaseDto> InsertRelease(ReleaseDto release)
        {
            ReleasePowerServer releasePowerSever = _mapper.Map<ReleasePowerServer>(release);
            await _context.AddAsync(releasePowerSever);
            await Save();
            return _mapper.Map<ReleaseDto>(releasePowerSever);
        }

        public async Task<bool> DeleteRange(long id)
        {
            ReleasePowerServer releasePowerServer = await _context.Releases.Include(y => y.Modules).Where(x => x.ReleaseId == id).FirstOrDefaultAsync();

            if (releasePowerServer == null) return false;

            _context.Remove(releasePowerServer);

            await Save();

            return true;
        }

        public async Task<IEnumerable<ReleaseDto>> GetAllIncludeModule()
        {
            List<ReleasePowerServer> releases = await _context.Releases.Include(x => x.Modules).ToListAsync();

            return _mapper.Map<List<ReleaseDto>>(releases);
        }

        public async Task<ReleaseDto> SelectByIdWithInclude(long id)
        {
            ReleasePowerServer release = await _context.Releases.Include(x => x.Modules).Where(y => y.ReleaseId == id).FirstOrDefaultAsync();

            return _mapper.Map<ReleaseDto>(release);
        }
        public async Task<ModuleDto> SelectModuleById(long id)
        {
            ModulePowerServer module = await _context.Modules.FirstOrDefaultAsync(x => x.ModuleId == id);

            return _mapper.Map<ModuleDto>(module);
        }
        public async Task<ModuleDto> InsertModule(ModuleDto module)
        {
            ModulePowerServer modulePowerServer = _mapper.Map<ModulePowerServer>(module);
            await _context.AddAsync(modulePowerServer);
            await Save();
            return _mapper.Map<ModuleDto>(modulePowerServer);
        }
        public async Task<ModuleDto> UpdateModules(ModuleDto module)
        {

            ModulePowerServer modulePowerServer = _mapper.Map<ModulePowerServer>(module);

            _context.Update(modulePowerServer);
            await Save();

            return _mapper.Map<ModuleDto>(modulePowerServer);
        }
        public async Task<ReleaseDto> UpdateReleases(ReleaseDto release)
        {

            ReleasePowerServer releasePowerServer = _mapper.Map<ReleasePowerServer>(release);

            _context.Update(releasePowerServer);
            await Save();

            return _mapper.Map<ReleaseDto>(releasePowerServer);
        }

        public async Task<bool> DeleteModule(long id)
        {
            ModulePowerServer modulePowerServer = await _context.Modules.Include(y => y.Feedbacks).Where(x => x.ModuleId == id).FirstOrDefaultAsync();

            if (modulePowerServer == null) return false;

            _context.RemoveRange(modulePowerServer);

            await Save();

            return true;
        }

        public async Task<AttachmentDto> AddFiles(AttachmentDto attachmentDto)
        {
            ZipFilePowerServer attachment = _mapper.Map<ZipFilePowerServer>(attachmentDto);
            await _context.ZipFilesPowerServer.AddAsync(attachment);
            await _context.SaveChangesAsync();
            return _mapper.Map<AttachmentDto>(attachment);
        }
    }
}
