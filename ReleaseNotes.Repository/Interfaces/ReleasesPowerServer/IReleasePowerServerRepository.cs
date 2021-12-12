using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNotes.Repository.Interfaces.ReleasesPowerServer
{
    public interface IReleasePowerServerRepository : IGenericRepository<Release>
    {
        public Task<Release>InsertRange(Release release);
        public Task<bool> DeleteRange(long id);
        public Task<IEnumerable<Release>> GetAllIncludeModule();
    }
}
