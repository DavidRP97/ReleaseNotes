using ReleaseNotes.Service.Models.Call;

namespace ReleaseNotes.Service.Interfaces
{
    public interface ICallService
    {
        Task<IEnumerable<CallViewModel>> FindAllCalls(string token);
        Task<CallViewModel> CreateCall(CallViewModel model, string token);
        Task<CallViewModel> FindCallById(long id, string token);
        Task<CallViewModel> UpdateCall(CallViewModel model, string token);
    }
}
