using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using System.Threading.Tasks;
using UploadFileOnAzureStorage.Logics;
using UploadFileOnAzureStorage.Models;

namespace UploadFileOnAzureStorage.Handlers
{
    public class UploadFileRequestHandler : IFileManagerLogics
    {
        private readonly BlobServiceClient _blobServiceClient;
        public UploadFileRequestHandler(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<byte[]> Get(DownloadFileRequest request)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("propose");

            var blobClient = blobContainer.GetBlobClient(request.Path);
            var downloadContent = await blobClient.DownloadAsync();
            using (MemoryStream ms = new())
            {
                await downloadContent.Value.Content.CopyToAsync(ms);
                return ms.ToArray();
            }
        }

        public async Task Upload(FileRequest model)
        {
            var blobContainer =  _blobServiceClient.GetBlobContainerClient("propose");
            var blobClient = blobContainer.GetBlobClient(model.Path+model.ImageFile.FileName);
            
            await blobClient.UploadAsync(model.ImageFile.OpenReadStream());
        }

       
    }
}
