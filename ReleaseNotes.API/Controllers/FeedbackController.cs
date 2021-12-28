using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Repository.DTO;
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
        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDto feedback)
        {
            if (feedback == null) return BadRequest();

            var addFeedback = await _feedbackRepository.InsertFeedback(feedback);

            return Ok(addFeedback); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetAll()
        {
            return Ok(await _feedbackRepository.GetAllFeedbacks());
        }
    }
}
