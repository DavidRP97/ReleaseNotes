using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));
        }
        [HttpGet]
        public async Task<ActionResult> GetConfig()
        {
            return Ok(await _emailRepository.GetConfig());
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteReceiver(long id)
        {
            var status = await _emailRepository.DeleteReceiver(id);

            if (!status) return BadRequest();
            return Ok(status);
        }
        [HttpPost]
        public async Task<ActionResult<ReceiverDto>> Create([FromBody] ReceiverDto receiver)
        {
            if (receiver == null) return BadRequest();

            return Ok(await _emailRepository.CreateReceiver(receiver));
        }
    }
}
