using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Entities.Model.Feedback;
using ReleaseNotes.Repository.Context;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.Repository.Repositories
{
    public class FeedbackRepository : GenericRepository<ReleasesFeedback>, IFeedbackRepository
    {
        private readonly NpgSqlContext _context;
        public FeedbackRepository(NpgSqlContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<int> FeedbacksNegativesPDV() => _context.Feedbacks.Where(x => x.FeedbackPositive != true && x.FeedbackFrom == FeedbackFrom.PDV).Count();

        public async Task<int> FeedbacksNegativesPowerServer() => _context.Feedbacks.Where(x => x.FeedbackPositive != true && x.FeedbackFrom == FeedbackFrom.PowerServer).Count();

        public async Task<int> FeedbacksPositivesPDV() => _context.Feedbacks.Where(x => x.FeedbackPositive == true && x.FeedbackFrom == FeedbackFrom.PDV).Count();

        public async Task<int> FeedbacksPositivesPowerServer() => _context.Feedbacks.Where(x => x.FeedbackPositive == true && x.FeedbackFrom == FeedbackFrom.PowerServer).Count();
    }
}
