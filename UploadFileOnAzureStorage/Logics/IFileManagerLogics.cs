using System.Threading.Tasks;
using UploadFileOnAzureStorage.Models;

namespace UploadFileOnAzureStorage.Logics
{
    public interface IFileManagerLogics
    {
        Task Upload(FileRequest model);
        Task<byte[]> Get(DownloadFileRequest request);
    }
}
