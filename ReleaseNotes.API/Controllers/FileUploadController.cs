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
        public FileUploadController(IWebHostEnvironment webHostEnvironment, ICallRepository callRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _callRepository = callRepository;
        }

        [HttpPost("Calls-Attachments")]
        public async Task<IActionResult> CallsAttachments([FromBody] AttachmentDto attachmentDto)
        {
            return Ok(await _callRepository.AddAttachment(attachmentDto));
        }

        [HttpPost("Upload-Files")]
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
