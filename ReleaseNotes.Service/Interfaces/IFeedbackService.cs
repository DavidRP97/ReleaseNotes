using ReleaseNotes.Service.Models.Feedback;

namespace ReleaseNotes.Service.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackViewModel>> FindAllFeedbacks(string token);
        Task<FeedbackViewModel> CreateFeedback(FeedbackViewModel model, string token);
    }
}
