using ReleaseNotes.Service.Models.Call;

namespace ReleaseNotes.Service.Interfaces
{
    public interface ICallService
    {
        Task<IEnumerable<CallViewModel>> FindAllCalls(string token);
    }
}
