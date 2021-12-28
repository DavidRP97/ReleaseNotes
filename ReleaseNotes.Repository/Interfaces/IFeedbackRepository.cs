using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Entities.Model.Feedback;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces.Generic;

namespace ReleaseNotes.Repository.Interfaces
{
    public interface IFeedbackRepository : IGenericRepository<ReleasesFeedback>
    {
        Task<int> FeedbacksNegativesPDV();
        Task<int> FeedbacksPositivesPDV();
        Task<int> FeedbacksNegativesPowerServer();
        Task<int> FeedbacksPositivesPowerServer();
        Task<FeedbackDto> InsertFeedback(FeedbackDto feedback);
        Task<IEnumerable<FeedbackDto>> GetAllFeedbacks();
    }
}
