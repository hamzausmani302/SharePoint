using BlazorApp1.Client.Services.UserService;
using BlazorApp1.Server.Service.FileDBService;
using BlazorApp1.Server.Service.UploadService;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;


using System.Text;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class FileController : Controller
    {
        private  IFileUpload fileuploadService;
        private FileDBService fileDBService;
        

        private readonly IAWSConfiguration configuration;

        public FileController( IAWSConfiguration config , FileDBService service) {
            
            configuration = config;
            fileDBService = service;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<FileS3>>> getFiles() {
            return await fileDBService.GetFiles();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DownloadFile>> getDocument(int id) {
            
            List<FileS3> response = await fileDBService.getFile(id);
            if (response.Count < 1) {
                return NotFound();
            }
            DownloadFile file = new DownloadFile() {
                FileName = response[0].file_name,
               
                ContentType = response[0].file_ext
            };
            fileuploadService = new FileUpload(configuration.AwsAccessKey, configuration.AwsSecretAccessKey, "", configuration.Region, configuration.BucketName);
            var res = await fileuploadService.downloadFile(file.FileName, configuration.BucketName, file);
            
            return  file;
        }
        [HttpGet("download/{id}")]
        public async Task<ActionResult> DownloadFile(int id) {
            try
            {
                List<FileS3> response = await fileDBService.getFile(id);
                if (response.Count < 1)
                {
                    return NotFound();
                }
                DownloadFile file = new DownloadFile()
                {
                    FileName = response[0].file_name,

                    ContentType = response[0].file_ext
                };
                fileuploadService = new FileUpload(configuration.AwsAccessKey, configuration.AwsSecretAccessKey, "", configuration.Region, configuration.BucketName);
                var res = await fileuploadService.downloadFile(file.FileName, configuration.BucketName, file);
                if (res == true)
                {
                    return  File(file.Content, file.ContentType, file.FileName);
                }
                return NotFound();
            }
            catch (FileNotFoundException e) {
                return NotFound();
            }
            catch (Exception e) {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> uploadFile(UploadFile fileToUpload) {
            try
            {
                
                fileuploadService = new FileUpload(configuration.AwsAccessKey, configuration.AwsSecretAccessKey, configuration.AwsSessionToken, configuration.Region, configuration.BucketName);
                BlazorApp1.Shared.S3Object obj = new BlazorApp1.Shared.S3Object()
                {
                    Name = fileToUpload.FileName,
                    BucketName = configuration.BucketName

                };
                bool result = await fileuploadService.uploadFile(fileToUpload , obj);
                Console.WriteLine("reuslt"+ result);

                //add fiel to database SQL * have to add got url to db
                Console.WriteLine(fileToUpload.ContentType + "" + fileToUpload.FileName);

                bool res = await fileDBService.PutFileToDB(new FileS3()
                {
                    
                    user_id = "1",
                    file_name = fileToUpload.FileName,
                    file_ext = fileToUpload.ContentType,
                    file_url = "test"
                });
                Console.WriteLine(res);

                



                return Ok("File Created Successfullyy");
            }
            catch (Exception e) {
                HttpContext.Response.StatusCode = 500;
                return Json(new Dictionary<string, string>() {
                    { "message" , e.Message}
                } );
            }
            
        }
            
    }
}
