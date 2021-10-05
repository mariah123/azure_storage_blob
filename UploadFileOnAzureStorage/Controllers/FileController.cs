using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UploadFileOnAzureStorage.Logics;
using UploadFileOnAzureStorage.Models;

namespace UploadFileOnAzureStorage.Controllers
{
    public class FileController : ControllerBase
    {

        private readonly IFileManagerLogics _fileManager;
        public FileController(IFileManagerLogics fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpPost(nameof(UploadFile))]
        public async Task<IActionResult> UploadFile([FromForm] FileRequest request)
        {

            if (request.ImageFile != null)
            {
                await _fileManager.Upload(request);

                return Ok("File Uploaded Successfully");
            }

            return Ok("File is empty.");
        }

        [Route("download")]
        [HttpGet]
        public async Task<IActionResult> Download(DownloadFileRequest request)
        {
            var imagBytes = await _fileManager.Get(request);

            return new FileContentResult(imagBytes, "application/octet-stream")
            {
                FileDownloadName = request.ImageName
            };
        }

        [Route("view")]
        [HttpGet]
        public async Task<IActionResult> View(DownloadFileRequest request)
        {            
            var imagBytes = await _fileManager.Get(request);

            return File(imagBytes, "image/webp");

        }
    }
}
