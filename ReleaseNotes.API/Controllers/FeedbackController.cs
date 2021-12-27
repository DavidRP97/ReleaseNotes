using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Entities.Model.Feedback;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReleasesFeedback>>> GetAll()
        {
            return Ok(await _feedbackRepository.GetAll());
        }

        [HttpGet("NegativesPDV")]
        public async Task<ActionResult<int>> NegativesFeedbackPDV() => await _feedbackRepository.FeedbacksNegativesPDV();

        [HttpGet("NegativesPowerServer")]
        public async Task<ActionResult<int>> NegativesFeedbackPowerServer() => await _feedbackRepository.FeedbacksNegativesPowerServer();

        [HttpGet("PositivesPDV")]
        public async Task<ActionResult<int>> PositivesFeedbackPDV() => await _feedbackRepository.FeedbacksPositivesPDV();

        [HttpGet("PositivesPowerServer")]
        public async Task<ActionResult<int>> PositivesFeedbackPowerServer() => await _feedbackRepository.FeedbacksPositivesPowerServer();
    }
}
