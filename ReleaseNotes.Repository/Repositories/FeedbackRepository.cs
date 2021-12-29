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
        public async Task<FeedbackDto> FindById(long id)
        {
            ReleasesFeedback releasesFeedback = await _context.Feedbacks.FirstOrDefaultAsync(x => x.FeedbackId == id);

            return _mapper.Map<FeedbackDto>(releasesFeedback);
        }
    }
}
