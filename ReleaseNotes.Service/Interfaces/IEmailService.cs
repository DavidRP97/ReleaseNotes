using ReleaseNotes.Service.Models.Email;

namespace ReleaseNotes.Service.Interfaces
{
    public interface IEmailService
    {
        Task<SenderEmailConfigViewModel> FindEmail(string token);
    }
}
