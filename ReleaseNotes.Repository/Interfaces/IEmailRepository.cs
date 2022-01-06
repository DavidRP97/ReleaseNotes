using ReleaseNotes.Entities.Model.Email;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IEmailRepository : IGenericRepository<SenderEmailConfig>
    {
        Task<ReceiverDto> CreateReceiver(ReceiverDto receiver);
        Task<EmailDto> AddOrUpdate(EmailDto email);
        Task<bool> DeleteReceiver(long id);
        Task<EmailDto> GetConfig();
    }
}
