using ReleaseNotes.Entities.Model.Calls;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface ICallRepository : IGenericRepository<Call>
    {
        Task<CallDto> CreateCall(CallDto call);
        Task<IEnumerable<CallDto>> GetAllCalls();
        Task<CallDto> UpdateCall(CallDto call);
        Task<CallDto> FindById(long id);
    }
}
