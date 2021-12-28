using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.API.Utils;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;
using System.Net;

namespace ReleaseNotes.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReleasePowerServerController : ControllerBase
    {
        private readonly IReleasePowerServerRepository _releasePowerServerRepository;
        public ReleasePowerServerController(IReleasePowerServerRepository releaseRepository)
        {
            _releasePowerServerRepository = releaseRepository ?? throw new ArgumentNullException(nameof(releaseRepository));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var release = await _releasePowerServerRepository.SelectByIdWithInclude(id);
            if (release == null) return NotFound();
            return Ok(release);
        }
        [HttpGet("Module/{id}")]
        public async Task<ActionResult> FindModuleById(long id)
        {
            var release = await _releasePowerServerRepository.SelectModuleById(id);
            if (release == null) return NotFound();
            return Ok(release);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReleaseDto>>> GetAll()
        {
            var releases = await _releasePowerServerRepository.GetAllIncludeModule();
            return Ok(releases);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReleaseDto>> Create([FromBody] ReleaseDto release)
        {
            try
            {
                if (release == null) return NotFound();
                var addRelease = await _releasePowerServerRepository.InsertRelease(release);
                return Ok(addRelease);
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;

                if (response.StatusCode.HasFlag(HttpStatusCode.Unauthorized))
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Não Autorizado, Faça login e tente novamente!");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no servidor!");
            }
        }
        [HttpPost("CreateModules")]
        [Authorize]
        public async Task<ActionResult<ModuleDto>> Create([FromBody] ModuleDto module)
        {
            if (module == null) return NotFound();

            var addRelease = await _releasePowerServerRepository.InsertModule(module);
            return Ok(addRelease);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ReleaseDto>> Update([FromBody] ReleaseDto release)
        {
            if (release == null) return NotFound();
            var addRelease = await _releasePowerServerRepository.UpdateReleases(release);
            return Ok(addRelease);
        }
        [HttpPut("UpdateModules")]
        [Authorize]
        public async Task<ActionResult<ModuleDto>> Update([FromBody] ModuleDto module)
        {
            if (module == null) return NotFound();
            var addRelease = await _releasePowerServerRepository.UpdateModules(module);
            return Ok(addRelease);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _releasePowerServerRepository.DeleteRange(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
        [HttpDelete("Module/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteModule(long id)
        {
            var status = await _releasePowerServerRepository.DeleteModule(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
