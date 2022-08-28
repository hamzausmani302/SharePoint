using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Service.FileDBService
{
    public class FileDBService : DbContext
    {
        protected readonly IConfiguration Configuration;

        public FileDBService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
            options.EnableSensitiveDataLogging();
        }

        private DbSet<FileS3>? Files { get; set; }

        public async  Task<List<FileS3>> GetFiles() {
            IQueryable<FileS3> response = Files.Where<FileS3>(b => 1 == 1);
            return await response.ToListAsync();
        }

        public async Task<bool> PutFileToDB(FileS3 s3File) {
            
            
            var response =  Files.Add(s3File);
            await this.SaveChangesAsync();
            
            Console.WriteLine("RESPONSE" + response.ToString());
            return response != null;
        }


        public async Task<List<FileS3>> getFile(int id) {
            IQueryable<FileS3> response = Files.Where<FileS3>(d=> d.id == id);
            return await response.ToListAsync();
        }
    }
}
