using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Repository.DTO;
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

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult>GetById(long id)
        {
            if (id == 0) return NotFound();

            return Ok(await _callRepository.GetById(id));   
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _callRepository.GetAll());
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CallDto call)
        {
            if (call == null) return BadRequest();

            return Ok(await _callRepository.CreateCall(call));
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<CallDto>> Update([FromBody] CallDto call)
        {
            if (call == null) return NotFound();
            var addCall = await _callRepository.UpdateCall(call);
            return Ok(addCall);
        }
    }
}
