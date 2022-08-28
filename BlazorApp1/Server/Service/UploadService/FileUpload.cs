using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BlazorApp1.Shared;
namespace BlazorApp1.Server.Service.UploadService
{
    public class FileUpload : IFileUpload
    {
        public readonly IAmazonS3 client;

        public FileUpload(string accessKey , string secretKey , string sessionToken , string region , string bucketName) {
            client = new AmazonS3Client(accessKey, secretKey  , RegionEndpoint.APSouth1);
        }

        public async  Task<bool> downloadFile(string filename , string bucketName , DownloadFile df)
        {
            Console.WriteLine(filename + " " + bucketName);
            MemoryStream? sm = null;
            try
            {
                GetObjectRequest request = new GetObjectRequest()
                {
                    BucketName = bucketName,
                    Key = filename
                };



                var response = await client.GetObjectAsync(request);
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    sm = new MemoryStream();
                    Console.WriteLine("Ok");
                    
                    await response.ResponseStream.CopyToAsync(sm);

                    await sm.ReadAsync(df.Content);
                    if (sm is null || sm.ToArray().Length < 1)
                    {
                        throw new FileNotFoundException();
                    }
                    df.Content = sm.ToArray();

                }
                else
                {
                    return false;
                }

                

                return true;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public async Task<bool> uploadFile(UploadFile fileToUpload , BlazorApp1.Shared.S3Object objectInfo)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                stream.Write(fileToUpload.Content, 0, fileToUpload.Content.Length);

                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = stream,
                    Key = fileToUpload.FileName,
                    BucketName = objectInfo.BucketName,
                    ContentType = fileToUpload.ContentType


                };

                var fileTransferUtility = new TransferUtility(client);
                
                await fileTransferUtility.UploadAsync(uploadRequest);

                return true;
            }
            catch (Exception e) {
                throw e;
            }
        }
    }
}
