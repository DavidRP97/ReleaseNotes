using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Entities.Model.Feedback;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class FeedbackRepository : GenericRepository<ReleasesFeedback>, IFeedbackRepository
    {
        private readonly NpgSqlContext _context;
        private IMapper _mapper;
        public FeedbackRepository(NpgSqlContext context, IMapper mapper) : base(context)
        {
            _context = context; 
            _mapper = mapper;   
        }

        public async Task<int> FeedbacksNegativesPDV() => _context.Feedbacks.Where(x => x.FeedbackPositive != true && x.FeedbackFrom == FeedbackFrom.PDV).Count();

        public async Task<int> FeedbacksNegativesPowerServer() => _context.Feedbacks.Where(x => x.FeedbackPositive != true && x.FeedbackFrom == FeedbackFrom.PowerServer).Count();

        public async Task<int> FeedbacksPositivesPDV() => _context.Feedbacks.Where(x => x.FeedbackPositive == true && x.FeedbackFrom == FeedbackFrom.PDV).Count();

        public async Task<int> FeedbacksPositivesPowerServer() => _context.Feedbacks.Where(x => x.FeedbackPositive == true && x.FeedbackFrom == FeedbackFrom.PowerServer).Count();

        public async Task<IEnumerable<FeedbackDto>> GetAllFeedbacks()
        {
            List<ReleasesFeedback> releases = await _context.Feedbacks.ToListAsync();

            return _mapper.Map<List<FeedbackDto>>(releases);
        }

        public async Task<FeedbackDto> InsertFeedback(FeedbackDto feedback)
        {
            ReleasesFeedback releasesFeedback = _mapper.Map<ReleasesFeedback>(feedback);

            await _context.AddAsync(releasesFeedback);
            await Save();

            return _mapper.Map<FeedbackDto>(releasesFeedback);
        }
    }
}
