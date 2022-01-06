using ReleaseNotes.Service.Models.Email;

namespace ReleaseNotes.Service.Interfaces
{
    public interface IEmailService
    {
        Task<SenderEmailConfigViewModel> FindEmail(string token);
        Task<bool> DeleteReceiver(long id, string token);
        Task<ReceiverViewModel> CreateReceiver(ReceiverViewModel model, string token);
    }
}
