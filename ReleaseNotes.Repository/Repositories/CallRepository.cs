using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.Calls;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class CallRepository : GenericRepository<Call>, ICallRepository
    {
        private readonly NpgSqlContext _context;
        private IMapper _mapper;
        public CallRepository(NpgSqlContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CallDto>> GetAllCalls()
        {
            List<Call> calls = await _context.Calls.ToListAsync();

            return _mapper.Map<List<CallDto>>(calls);
        }
    }
}
