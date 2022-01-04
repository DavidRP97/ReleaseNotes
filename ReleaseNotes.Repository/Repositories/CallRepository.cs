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

        public async Task<CallDto> CreateCall(CallDto call)
        {
            Call createCall = _mapper.Map<Call>(call);

            await _context.AddAsync(createCall);
            await Save();

            return _mapper.Map<CallDto>(createCall);
        }

        public async Task<CallDto> FindById(long id)
        {
            Call call = await _context.Calls.FirstOrDefaultAsync(x => x.FeedbackId == id);

            return _mapper.Map<CallDto>(call);
        }

        public async Task<IEnumerable<CallDto>> GetAllCalls()
        {
            List<Call> calls = await _context.Calls.ToListAsync();

            return _mapper.Map<List<CallDto>>(calls);
        }

        public async Task<CallDto> UpdateCall(CallDto call)
        {
            Call createCall = _mapper.Map<Call>(call);

            _context.Update(createCall);
            await Save();

            return _mapper.Map<CallDto>(createCall);
        }
    }
}
