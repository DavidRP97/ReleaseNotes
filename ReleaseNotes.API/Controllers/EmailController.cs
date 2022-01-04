using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public async Task<ActionResult> GetConfig()
        {
            return Ok(await _emailRepository.GetConfig()); 
        }
    }
}
