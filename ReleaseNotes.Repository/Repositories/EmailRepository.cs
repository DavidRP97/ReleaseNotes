using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.Email;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class EmailRepository : GenericRepository<SenderEmailConfig>, IEmailRepository
    {
        private readonly NpgSqlContext _context;
        private IMapper _mapper;
        public EmailRepository(NpgSqlContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmailDto> AddOrUpdate(EmailDto email)
        {
            SenderEmailConfig senderEmail = _mapper.Map<SenderEmailConfig>(email);

            var exist = await _context.FindAsync<SenderEmailConfig>(senderEmail);

            if (exist == null) await _context.SenderEmailConfig.AddAsync(senderEmail);
            else _context.SenderEmailConfig.Update(senderEmail);

            await Save();

            return _mapper.Map<EmailDto>(senderEmail);
        }

        public async Task<EmailDto> GetConfig()
        {
            SenderEmailConfig senderEmail = await _context.SenderEmailConfig.Include(x => x.Sender).Include(y => y.Receivers).FirstOrDefaultAsync();

            return _mapper.Map<EmailDto>(senderEmail);
        }
    }
}
