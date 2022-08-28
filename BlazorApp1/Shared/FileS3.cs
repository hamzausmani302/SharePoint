using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class FileS3
    {
        public int id { get; set; }
        public string user_id { get; set; }
        
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public string file_url { get; set; }
    }
}
