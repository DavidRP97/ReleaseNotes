using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Repository.DTO;
using ReleaseNotes.Repository.Interfaces;

namespace ReleaseNotes.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly ICallRepository _callRepository;
        private readonly IReleasePowerPDVRepository _releasePowerPDVRepository;
        private readonly IReleasePowerServerRepository _releasePowerServerRepository;
        public FileUploadController(IWebHostEnvironment webHostEnvironment, ICallRepository callRepository,
            IReleasePowerServerRepository releasePowerServerRepository, IReleasePowerPDVRepository releasePowerPDVRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _callRepository = callRepository;
            _releasePowerPDVRepository = releasePowerPDVRepository;
            _releasePowerServerRepository = releasePowerServerRepository;
        }

        [HttpPost("Calls-Attachments")]
        public async Task<IActionResult> CallsAttachments([FromBody] AttachmentDto attachmentDto)
        {
            return Ok(await _callRepository.AddAttachment(attachmentDto));
        }
        [HttpPost("Upload-Zip-Files-Pdv")]
        public async Task<List<string>> UploadZipFiles([FromForm] List<IFormFile> items, long releaseId)
        {            
            var file = new List<string>();

            foreach (var item in items)
            {
                if (item.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads-pdv-versions\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fs = System.IO.File.Create(path + item.FileName))
                    {
                        await item.CopyToAsync(fs);

                        await fs.FlushAsync();

                        file.Add(path + item.FileName);
                        AttachmentDto attachment = new AttachmentDto
                        {
                            ReleasePowerServerId = releaseId,
                            FilePath = path + item.FileName,
                        };
                        await _releasePowerPDVRepository.AddFiles(attachment);
                    }
                }
            }
            return file;
        }
        [HttpPost("Upload-Zip-Files-PowerServer")]
        public async Task<List<string>> UploadZipFilesPowerServer([FromForm] List<IFormFile> items, long releaseId)
        {
            var entity = await _releasePowerServerRepository.GetById(releaseId);

            var file = new List<string>();

            foreach (var item in items)
            {
                if (item.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + $"\\Versions\\Upload-PowerServer-Version-{entity.VersionNumber}\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fs = System.IO.File.Create(path + item.FileName))
                    {
                        await item.CopyToAsync(fs);

                        await fs.FlushAsync();

                        file.Add(path + item.FileName);
                        AttachmentDto attachment = new AttachmentDto
                        {
                            ReleasePowerServerId = releaseId,
                            FilePath = path + item.FileName,
                        };
                        await _releasePowerServerRepository.AddFiles(attachment);
                    }
                }
            }
            return file;
        }

        [HttpPost("Upload-Images")]
        public async Task<List<string>> Upload([FromForm] List<IFormFile> items)
        {
            var imagens = new List<string>();

            foreach (var item in items)
            {
                if (item.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fs = System.IO.File.Create(path + item.FileName))
                    {
                        await item.CopyToAsync(fs);

                        await fs.FlushAsync();

                        imagens.Add(path + item.FileName);

                    }
                }
            }
            return imagens;

        }
    }
}
