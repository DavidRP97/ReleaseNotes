using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly ICallRepository _callRepository;

        public CallController(ICallRepository callRepository)
        {
            _callRepository = callRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _callRepository.GetAll());
        }
    }
}
