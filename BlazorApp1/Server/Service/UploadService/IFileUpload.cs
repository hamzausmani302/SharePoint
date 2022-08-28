using BlazorApp1.Shared;

namespace BlazorApp1.Server.Service.UploadService
{
    public interface IFileUpload
    {
        public Task<bool> uploadFile(UploadFile file, S3Object objectInfo);
        public Task<bool> downloadFile(string filename , string bucketName , DownloadFile df);
    }
}
