using ReleaseNotes.Entities.Model.Email;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IEmailRepository : IGenericRepository<SenderEmailConfig>
    {
        Task<EmailDto> AddOrUpdate(EmailDto email);
        Task<EmailDto> GetConfig();
    }
}
