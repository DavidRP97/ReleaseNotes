using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Service.PowerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseNotes.Service.Interfaces
{
    public  interface IRealesePowerServerService
    {
        Task<IEnumerable<ReleasePowerServerViewModel>> FindAllReleases();
        Task<ReleasePowerServerViewModel> FindReleaseById(long id, string token);
        Task<ReleasePowerServerViewModel> CreateRelease(ReleasePowerServerViewModel model, string token);
        Task<ReleasePowerServerViewModel> UpdateRelease(ReleasePowerServerViewModel model, string token);
        Task<bool> DeleteReleaseById(long id, string token);
    }
}
