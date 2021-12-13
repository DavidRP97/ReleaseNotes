﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Entities.Model.ReleasesPowerServer;
using ReleaseNotes.Repository.Interfaces;

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
            var release = await _releasePowerServerRepository.GetById(id);
            if (release == null) return NotFound();
            return Ok(release);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Release>>> GetAll()
        {
            var releases = await _releasePowerServerRepository.GetAllIncludeModule();
            return Ok(releases);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<Release>> Create([FromBody] Release release)
        {
            if (release == null) return NotFound();            
            var addRelease = await _releasePowerServerRepository.InsertRange(release);            
            return Ok(addRelease);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<Release>> Update([FromBody] Release release)
        {
            if (release == null) return NotFound();
            var addRelease = await _releasePowerServerRepository.Insert(release);
            return Ok(addRelease);
        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _releasePowerServerRepository.DeleteRange(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
