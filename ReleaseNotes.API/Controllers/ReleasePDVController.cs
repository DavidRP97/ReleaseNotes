using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.API.Utils;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReleasePDVController : ControllerBase
    {
        private readonly IReleasePowerPDVRepository _releasePowerPDVRepository;
        public ReleasePDVController(IReleasePowerPDVRepository releaseRepository)
        {
            _releasePowerPDVRepository = releaseRepository ?? throw new ArgumentNullException(nameof(releaseRepository));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(long id)
        {
            var release = await _releasePowerPDVRepository.SelectByIdWithInclude(id);
            if (release == null) return NotFound();
            return Ok(release);
        }
        [HttpGet("Module/{id}")]
        public async Task<ActionResult> FindModuleById(long id)
        {
            var release = await _releasePowerPDVRepository.SelectModuleById(id);
            if (release == null) return NotFound();
            return Ok(release);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReleasePDV>>> GetAll()
        {
            var releases = await _releasePowerPDVRepository.GetAllIncludeModule();
            return Ok(releases);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult<ReleasePDV>> Create([FromBody] ReleasePDV release)
        {
            if (release == null) return NotFound();

            var addRelease = await _releasePowerPDVRepository.InsertRelease(release);
            return Ok(addRelease);
        }

        [HttpPost("CreateModules")]
        [Authorize]
        public async Task<ActionResult<ModulePDV>> Create([FromBody] ModulePDV module)
        {
            if (module == null) return NotFound();

            var addRelease = await _releasePowerPDVRepository.InsertModule(module);
            return Ok(addRelease);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ReleasePDV>> Update([FromBody] ReleasePDV release)
        {
            if (release == null) return NotFound();
            var addRelease = await _releasePowerPDVRepository.Update(release);
            return Ok(addRelease);
        }
        [HttpPut("UpdateModules")]
        [Authorize]
        public async Task<ActionResult<ModulePDV>> Update([FromBody] ModulePDV module)
        {
            if (module == null) return NotFound();
            var addRelease = await _releasePowerPDVRepository.UpdateModules(module);
            return Ok(addRelease);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var status = await _releasePowerPDVRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
        [HttpDelete("Module/{id}")]
        //[Authorize]
        public async Task<ActionResult<bool>> DeleteModule(long id)
        {
            var status = await _releasePowerPDVRepository.DeleteModule(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
