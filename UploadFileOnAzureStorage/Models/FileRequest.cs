using Microsoft.AspNetCore.Http;
using System;

namespace UploadFileOnAzureStorage.Models
{
    public class FileRequest
    {
        public Guid ProfileId { get; set; }
        public string DocumentType { get; set; }
        public IFormFile ImageFile { get; set; }

        public string Path
        {
            get
            {
                if (DocumentType == "Photo") return $"{ProfileId}/{DocumentType}/";
                else return $"{ProfileId}/{DocumentType}/";

            }
        }
    }

    public class DownloadFileRequest
    {
        public Guid ProfileId { get; set; }
        public string DocumentType { get; set; }
        public string ImageName { get; set; }

        public string Path
        {
            get
            {
                if (DocumentType == "Photo") return $"{ProfileId}/{DocumentType}/{ImageName}";
                else return $"{ProfileId}/{DocumentType}/{ImageName}";

            }
        }
    }

    public class DeleteFileRequest
    {
        public Guid ProfileId { get; set; }
        public string DocumentType { get; set; }
        public string ImageName { get; set; }

        public string Path
        {
            get
            {
                if (DocumentType == "Photo") return $"{ProfileId}/{DocumentType}/{ImageName}";
                else return $"{ProfileId}/{DocumentType}/{ImageName}";

            }
        }
    }

}
