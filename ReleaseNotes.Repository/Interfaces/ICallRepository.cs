using ReleaseNotes.Entities.Model.Calls;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface ICallRepository : IGenericRepository<Call>
    {
        Task<IEnumerable<CallDto>> GetAllCalls();
    }
}
